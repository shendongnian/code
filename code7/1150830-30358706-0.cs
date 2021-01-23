    public class Question : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            OnPropertyChangedExplicit(propertyName);
        }
        protected void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            var memberExpression = (MemberExpression)projection.Body;
            OnPropertyChangedExplicit(memberExpression.Member.Name);
        }
        void OnPropertyChangedExplicit(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        int _id = false;
        public int id
        {
            get { return _id; }
            set { if (value != _id) { _id= value; OnPropertyChanged(); } }
        }
        string _sequencenumber = false;
        public int SequenceNumber 
        {
            get { return _sequencenumber ; }
            set { if (value != _sequencenumber ) { _sequencenumber = value; OnPropertyChanged(); } }
        }
    }
