    class Conditional<T> // or however you want to call it
    {
        public T Source { get; set; } // the initial source object
        public bool Result { get; set; } // weather the IfTrue method called the action
        public void Else(Action<T> action)
        {
            if (!Result)
                action(Source);
        }
    }
