    public class MyViewModel : ViewModelBase
    {
        private int myProperty;
        public int MyProperty
        {
            get { return myProperty; }
            set { SetProperty(ref myProperty, value);
        }
    }
