        public event PropertyChangedEventHandler PropertyChanged;
        public void PropChange(string prop)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
