    public class ExceptionResponse
        {
            public string Message { get; set; }
            public string ExceptionMessage { get; set; }
            public string ExceptionType { get; set; }
            public string StackTrace { get; set; }
            public ExceptionResponse InnerException { get; set; }
             
            public override String ToString()
            {
                return "Message: " + Message + "\r\n "
                    + "ExceptionMessage: " + ExceptionMessage + "\r\n "
                    + "ExceptionType: " + ExceptionType + " \r\n "
                    + "StackTrace: " + StackTrace + " \r\n ";           
			}  
        }
    
