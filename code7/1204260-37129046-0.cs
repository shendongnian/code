    using (var response = client.GetObject(request))
    {
      response.WriteObjectProgressEvent += Response_WriteObjectProgressEvent;
      response.WriteResponseStreamToFile(@"C:\Downloads\file.exe");
    }
    private static void Response_WriteObjectProgressEvent(object sender, WriteObjectProgressArgs e)
    {
      Debug.WriteLine($"Tansfered: {e.TransferredBytes}/{e.TotalBytes} - Progress: {e.PercentDone}%");
    }
