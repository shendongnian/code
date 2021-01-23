        public event EventHandler HelloListener;
        public void SayHello() {
            Console.WriteLine("Hello!!");
    
            // Notify everybody that may be interested.
            if(HelloListener != null) {
                HelloListener(this, EventArgs.Empty);
            }
        }
