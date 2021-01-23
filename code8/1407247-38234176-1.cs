    static void Main(string[] args)
    {
        string json_string = @"{""Sub_Status"": ""Pending"",
                                ""Status"": ""Pending"",
                                ""Patient_Gender"": ""M""}";
    
        Case caseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Case>(json_string);
    
        List<string> acceptedStatuses = new List<string> { "PENDING", "DISPENSED", "SHIPMENT" };
    
        bool test = statuses.Any(s => s.Equals(caseObj.Status, StringComparison.OrdinalIgnoreCase))
                                && !string.IsNullOrWhiteSpace(caseObj.Patient_Gender);
    }
