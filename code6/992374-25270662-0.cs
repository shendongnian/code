    using System.ComponentModel;
    namespace WpfMagic
    {
        public class MyViewModel : INotifyPropertyChanged
        {
            private bool flag;
            public bool Flag
            {
                get { return flag; }
                set
                {
                    if (value != flag)
                    {
                        flag = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("Flag"));
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
        }
    }
