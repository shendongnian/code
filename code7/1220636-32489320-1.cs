        async Task<string> GetSomeValueEvent()
        {
            // Some other stuff ... 
            return "Hello World"; 
        }
    
        IAsyncOperation<string> GetSomeValueEventWrapper()
        {
            return GetSomeValueEvent().AsAsyncOperation();
        }
    
        FooCS()
        {
            FooC c = new ref FooC(); 
            c.m_GetSomeValueEvent = GetSomeValueEventWrapper;
            // Some other stuff ...
        }
