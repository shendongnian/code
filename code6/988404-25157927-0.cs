    // Get Last Exception
    var exceptionDetails = ExceptionHandler.GetLastException();
    // Let you manage all the exceptions from Tweetinvi
    ExceptionHandler.SwallowWebExceptions = false;
    // Log Exceptions
    ExceptionHandler.WebExceptionReceived += (sender, args) => { var exceptionReceived = args.Value; };
