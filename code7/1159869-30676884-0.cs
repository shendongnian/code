        private int _Text;
        public int Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                if (this._Text != value)
                {
                    this._Text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }
