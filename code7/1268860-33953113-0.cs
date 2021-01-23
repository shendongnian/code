    public class Model 
    {
        public int SomeValue { get; set; }
    }
    public ViewModel : INotifyPropertyChanged
    {
        private Model _model = new Model();
        public int SomeModelValue
        {
            get { return _model.SomeValue; }
            set 
            {
                _model.SomeValue = value;
                //Notify property changed
            }
        }
        ...
    }
