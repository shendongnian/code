        public void AfterTest(TestDetails testDetails)
        {
            if(TestContext.CurrentContext.Result.State == TestState.Error)
            {
                return;   
            } 
            // don't run it if there is any exception
            // how to check whether an exception is thrown from Nunit
            // ...
        }
