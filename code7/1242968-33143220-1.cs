    class Publisher
    {
        public event EventHandler x;
        public string Name { get; set; }        
        
        public void Raise()
        {
           EventHandler x = this.x;
           if (x != null)
              x(this, EventArgs.Empty);
        }
    }
