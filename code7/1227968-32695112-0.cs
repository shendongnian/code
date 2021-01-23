    public class C<T> where T : A
    {
        private ObservableCollection<T> _as = new ObservableCollection<T>();
        public ObservableCollection<T> As
        {
            get { return _as; }
            set { _as = value; }
        }
    }
