        public class Equip:INotifyPropertyChanged
    {
       public Equip()
        {
            PrintCode = "All";
        }
        private string printcode;
        public string PrintCode
        {
            get { return printcode; }
            set { printcode = value; OnPropertychanged("PrintCode"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertychanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
