    AsyncLocal<string> Data = new AsyncLocal<string>();
    Data.Value = "One";
    using (ExecutionContext.SuppressFlow())
    {    
        Task.Factory.StartNew( () =>
        {
            string InnerValue = Data.Value;
            //InnerValue is null.
        } );
    }
