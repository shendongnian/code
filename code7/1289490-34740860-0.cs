    public class MyRecord : INotifyPropertyChanged
    {      
        private string a;
        public string A
        {
            get { return a; }
            set { a = value;
            OnPropertyChanged("A");
            OnPropertyChanged("SecondList");
            }
        }
        private string b;
        public string B
        {
            get { return b; }
            set { b = value;
            OnPropertyChanged("B");
            }
        }
        private List<ComboBoxItem> firstList;
        public List<ComboBoxItem> FirstList
        {
            get { return firstList; }
            set { firstList = value;
            OnPropertyChanged("FirstList");
            }
        }
        private List<ComboBoxItem> secondList;
        public List<ComboBoxItem> SecondList
        {
            get { return secondList.Where(x=>x.value.StartsWith(A)).ToList(); }
            set { secondList = value;
            OnPropertyChanged("SecondList");
            }
        }
        
    }
