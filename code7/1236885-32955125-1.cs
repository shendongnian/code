        public event PropertyChangedEventHandler PropertyChanged;
        public bool chkSpecifyDateRange
        {
            get { return obj.SpecifyDateRange; }
            set 
            { 
                obj.SpecifyDateRange = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("chkSpecifyDateRange"));
            }
        }
    
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(PropertyChanged != null)
               PropertyChanged(sender, args);
        }
