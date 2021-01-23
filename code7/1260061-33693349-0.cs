    private readonly string fileNameAndPath = @"C:\Apps\TestService\log\Test.txt";
    private Object thisLock = new Object();
    public void LogRequestDetails_SendOrderRequestMethod(Message request, SendOrderRequest quoteRequest)
    {
      lock (thisLock)
      {
         // Create a writer and open the file:
         StreamWriter log;
         if (!File.Exists(fileNameAndPath))
           log = new StreamWriter(fileNameAndPath);
         else
           log = File.AppendText(fileNameAndPath);
         // Write to the file:
         log.WriteLine("=================================");
         log.WriteLine(DateTime.Now);
         log.WriteLine("Price : " + quoteRequest.Price);
         log.WriteLine("QuoteId : " + quoteRequest.QuoteId);
         log.WriteLine("SecurityId : " + quoteRequest.SecurityId);
         log.WriteLine();
         log.WriteLine("Request string : " + request.ToString());
         log.WriteLine("=================================");
         log.WriteLine("\n");
         // Close the stream:
         log.Close();
     }
    }
