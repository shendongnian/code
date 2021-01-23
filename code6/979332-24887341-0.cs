    public string CurrentTime
        {
            get
            {
                if (this._CurrentTime == null)
                {
                    this._CurrentTime = default(string);
                }
                return this._CurrentTime;
            }
            set
            {
                if (value != null && !value.Equals(this._CurrentTime))
                {
                    this._CurrentTime = value;
                    this.OnPropertyChanged("CurrentTime");
                }
            }
        }
