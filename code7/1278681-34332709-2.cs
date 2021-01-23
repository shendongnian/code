    public class BaseData:BaseObservableObject
    {
        private string _name;
        private string _description;
        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                Description = "a string that should be displayed immediatly";
            }
        }
        public virtual object Description
        {
            get { return _description; }
            set
            {
                _description = (string) value;
                OnPropertyChanged();
            }
        }
    }
