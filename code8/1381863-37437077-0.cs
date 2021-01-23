    public static ExecuteMultipleRequest MultipleRequest { get; set; }
    private const int BatchSize = 250;
    public static long LastBatchTime { get; set; }
    private static void Batch(IOrganizationService service, OrganizationRequest request)
    {
        if (MultipleRequest.Requests.Count == BatchSize)
        {
            ExecuteBatch(service);
        }
        MultipleRequest.Requests.Add(request);
    }
    private static void ExecuteBatch(IOrganizationService service)
    {
        if (!MultipleRequest.Requests.Any())
        {
            return;
        }
        Log("Executing Batch size {0}.  Last Batch was executed in {1}",MultipleRequest.Requests.Count, LastBatchTime);
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        var response = (ExecuteMultipleResponse)service.Execute(MultipleRequest);
        watch.Stop();
        LastBatchTime = watch.ElapsedMilliseconds;
        Log("Completed Executing Batch in " + watch.ElapsedMilliseconds);
        WriteLogsToConsole();
        var errors = new List<string>();
        // Display the results returned in the responses.
        foreach (var responseItem in response.Responses)
        {
            // A valid response.
            if (responseItem.Fault != null)
            {
                errors.Add(string.Format(
                    "Error: Execute Multiple Response Fault.  Error Code: {0} Message {1} Trace Text: {2} Error Keys: {3} Error Values: {4} ",
                    responseItem.Fault.ErrorCode,
                    responseItem.Fault.Message,
                    responseItem.Fault.TraceText,
                    responseItem.Fault.ErrorDetails.Keys,
                    responseItem.Fault.ErrorDetails.Values));
            }
        }
        MultipleRequest.Requests.Clear();
        if (errors.Any())
        {
            throw new Exception(string.Join(Environment.NewLine, errors));
        }
    }
