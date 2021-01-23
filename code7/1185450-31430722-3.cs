    public class ViewModel
    {
        private Movie _Model;
        public Movie Model
        {
            get { return _Model; }
            set 
            { 
                _Model = value;
                //Property changed stuff (if required)
            }
        }
        
        ...
    }
