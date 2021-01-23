    public class Item : INotifyPropertyChanged
    {
        private Double value;
        public Double Value
        {
            get { return this.value; }
            set { this.value = value; Changed("Value"); }
        }
        private Double minimum;
        public Double Minimum
        {
            get { return minimum; }
            set { minimum = value; Changed("Minimum"); }
        }
        private Double maximum;
        public Double Maximum
        {
            get { return maximum; }
            set { maximum = value; Changed("Maximum"); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; Changed("Name"); }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; Changed("Status"); }
        }
        private void Changed(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
