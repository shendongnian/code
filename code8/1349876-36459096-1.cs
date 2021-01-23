    public class ExceptionWrapper : Exception
    {
        public new Exception InnerException { get; set; }
    }
    throw new ExceptionWrapper { InnerException = overall.Exception };
