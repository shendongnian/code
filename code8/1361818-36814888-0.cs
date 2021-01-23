      private Object myItem;
        public Object SelectedItem
        {
            get { return myItem; }
            set
            {
                myItem = value;
                ItemChanged(myItem); // Function to be called
            }
        }
