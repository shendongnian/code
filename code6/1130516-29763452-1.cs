     public int A
        {
            get
            {
                
                return a;
            }
            set
            {
                a = value;
                this.UserColorSelected = Color.FromArgb(value, this.R, this.G, this.B);
                this.PropertyChanged(this, new PropertyChangedEventArgs("A"));
            }
        }
    
