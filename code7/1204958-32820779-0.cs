    private Task _feedTask;
    private SslStream _sslStream;
    private StreamReader _streamReader;
    private static readonly log4net.ILog _logger
            = log4net.LogManager.GetLogger(
                    System.Reflection.MethodBase.GetCurrentMethod()
                     .DeclaringType);
    
    public void CreateNewTaskAndStartReadingFeed()
    {
        _feedTask = new Task(() => StartReadingFeed());
        _feedTask.Start();
    }
    
    public void StartReadingFeed()
    {
       try
       {
           while (true)
           {
               var message = GetStreamMessage();
    
               if (message != null)
               {
                   Debug.WriteLine("StartReadingFeed message: " + message);
                   OnReceivedSomething(message);
               }
               else
               {
                   Debug.WriteLine("StartReadingFeed message was null");
               }
           }
       }
       catch (Exception ex)
       {
           var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
           Debug.WriteLine($"Method {methodName} failed " + ex.Message);
           Debug.WriteLine("Creating a new task and starts to reed feed again");
           _logger.Error("StartReadingFeed failed", ex);
           CreateNewTaskAndStartReadingFeed();
       }
    }
    
    public string GetStreamMessage()
    {
        try
        {
            return _sslStream.CanRead ? _streamReader.ReadLine() : null;
        }
        catch (Exception ex)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Debug.WriteLine($"Method {methodName} failed " + ex.Message);
            _logger.Error($"{methodName} failed.", ex);
            return null;
        }
    }
