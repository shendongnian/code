    class Test
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                //Check if you are assigning the same value
                if (Equals(name, value))
                    return;
                name = value;
                OnNameChanged();
            }
    
            public event EventHandler NameChanged;
    
            protected virtual void OnNameChanged()
            {
                var handler = NameChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
    }
