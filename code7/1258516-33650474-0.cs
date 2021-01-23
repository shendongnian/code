    public class Car : INotifyPropertyChanged
    {
        private string _Model;
        public string Model
        {
            get { return _Model; }
            set 
            { 
                _Model = value;
                NotifyOfPropertyChange();
            }
        }
        ...
    }
    public class CarViewModel
    {
        //The entire model is exposed to the view.
        public Car Model { get; set; }
        ...
