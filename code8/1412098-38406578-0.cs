    public class Model1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _property;
        public string Property
        {
            get { return _property; }
            set
            {
                _property = value;
                OnPropertyChanged("Property");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Model2
    {
        public Model2()
        {
            // You might be storing your Model1 as a property in the Model2?
            // I don't know, but I've put it in the constructor just for example.
            var model1 = new Model1();
            model1.PropertyChanged += OnModel1PropertyChanged;
        }
        private void OnModel1PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Property")
            {
                // Do stuff here when the right property has changed in model 1
            }
        }
    }
