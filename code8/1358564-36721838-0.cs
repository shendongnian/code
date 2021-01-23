    class DbService
    {
        public void SomeDbAction(SomeDbContextObject backendContext)
        {
            
                // Some actions using the context
            
        }
        public void SomeDbAction()
        {
            using (var context = CreateNewContextObject())
            {
                SomeDbAction(context);
            }
        }
    }
