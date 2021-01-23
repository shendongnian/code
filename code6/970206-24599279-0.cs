        public string Description { get; set; }
        public char HotKey { get; set; }
        public Func<T> FirstHandler { get; set; }       // returns some value
        public Action<T> SecondHandler { get; set; }    // does not return any value
        // let's use this method to invoke the first handler
        public T DoSomething()
        {
            // this handler is of type Func<T> so it will return a value of type T
            return this.FirstHandler.Invoke();
        }
        // let's use this method to invoke the second handler
        public void DoSomethingElse(T input)
        {
            this.SecondHandler.Invoke(input);
        }
    }
