     public class Menuitems //Impliment INotifyPropertyChanged Interface
        {
            private List<string> _Title = new List<string>();
            private ICommand _Command;
            private object _Commandparameter;            
            public List<string> Title
            {
                get { return _Title; }
                set { _Title = value; NotifyPropertyChanged(); }
            }
            public ICommand Command
            {
                get { return _Command; }
                set { _Command = value; NotifyPropertyChanged(); }
            }
            public object CommandParameter
            {
                get { return _Commandparameter; }
                set { _Commandparameter = value; NotifyPropertyChanged(); }
            }           
        }
