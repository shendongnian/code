        public Task<DisposableAction> EnterAsync()
        {
            container = new Container(); // class
            // I'm using AsyncLocal instead of LogicalCallContext but it's pretty much the same thing
            _entered.Value = container;            
            return EnterAsync(container);
        }
        async Task<DisposableAction> EnterAsync(Container container)
        {
             // real work
        }
