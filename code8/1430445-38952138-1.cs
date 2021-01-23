    public abstract BaseClass
    {
        private List<Exception> unhandledExceptions = new List<Exception>();
        protected BaseClass()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }
    private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var ex = e.ExceptionObject as Exception;
        if (ex != null)
            this.UnhandledExceptions.Add(ex);
    }
    public List<Exception> LastKnownExceptions
    {
        get { return this.unhandledExceptions; }
    }
