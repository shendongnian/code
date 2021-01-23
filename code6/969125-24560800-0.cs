    public class MyDataContext : INotifyPropertyChanged
        private string number;
        public string Number {
            get {return number;}
            set {number = value; NotifyPropertyChanged("Number");}
        }
    // implement the interface of INotifyPropertyChanged here
    // ....
    }
