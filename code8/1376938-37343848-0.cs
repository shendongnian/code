    public class Item : INotifyPropertyChanged
    {
        private string name;
        private decimal price;
        private int count;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Name {            
            get
            {
                return this.name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value != this.Price)
                {
                    price = value;
                    OnPropertyChanged();
                    OnPropertyChanged("TotalPrice");
                }
            }
        }
        public int Count {
            get
            {
                return count;
            }
            set
            {
                if (value != count)
                {
                    count = value;
                    OnPropertyChanged();
                    OnPropertyChanged("TotalPrice");
                }
            }
        }
        public decimal TotalPrice
        {
            get { return Price * Count;  }
        }
    }
