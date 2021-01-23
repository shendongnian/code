    public class CustomEventArgs<T> : EventArgs
    {
        public T CustomArgs { get; set; }
    }
    public class Example<T>
    {
        public Example()
        {
            this.MyEvent += this.Handler;
        }
        public event EventHandler<CustomEventArgs<T>> MyEvent;
        private void Handler(object sender, CustomEventArgs<T> args)
        {
            
        }
    }
