    public class Source : INotifyPropertyChanged
    {        
        public string HeaderText2 { set
            {
                headerText2 = value;
                OnPropertyChanged("HeaderText2");
            }
            get
            {
                return headerText2;
            }
        }
        string headerText2;
        ...
    }
