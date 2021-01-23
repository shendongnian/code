    public class MyDataContext : INotifyPropertyChanged
        private string number;
        public string Number {
            get {return number;}
            set {number = value; NotifyPropertyChanged("Number");}
        }
    // implement the interface of INotifyPropertyChanged here
    // ....
    }
    public class MainWindow() : Window
    {
         private MyDataContext ctx = new MyDataContext();
         //This thing is out of my head, so please don't nail me on the details
         //but you should get the idea ...
         private void InitializeComponent() {
            //...
            //... some other initialization stuff
            //...
            this.Datacontext = ctx;
         }
    }
