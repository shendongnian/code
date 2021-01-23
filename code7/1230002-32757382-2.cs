        public String Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                terminalsViewSource.View.Refresh();
            }
        }
    
