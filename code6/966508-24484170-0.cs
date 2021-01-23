        private bool valueChangedByUser = false;
        private double value = 5;
        public double Value
        {
            get 
            { 
                return value; 
            }
            set 
            { 
                valueChangedByUser = true;  
                this.value = value; 
                OnPropertyChanged("Value"); 
            }
        }
