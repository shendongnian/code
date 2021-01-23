    public class CarViewModel
    {
        private Car _Car;
        //The model property is exposed to the view, not the model itself.
        public string CarModel
        {
            get { return _Car.Model; }
            set 
            { 
                _Car.Model = value;
                NotifyOfPropertyChange();
            }
        }
        ...
