    public class PlainOldObject : BaseNotifyPropertyChanged
    {
        public int MyProperty
        {
            get { return Get<int>(); }
            set { Set(value); }
        }
    }
