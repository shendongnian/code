    public class Person : BindableObject
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
    }
