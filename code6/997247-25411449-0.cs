    public class ItemModel
    {
        public String amountString 
        { 
            get 
            {
                return this._amountString;
            };
            set
            { 
                if (this._amountString == value)
                    return;
                HandleChanges(value);
                this._amountString = value;
                this.OnPropertyChanged("amountString");
            }
        }
    }
