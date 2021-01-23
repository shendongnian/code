    public class Model : INotifyPropertyChanged
    {
        private string _Nazwa;
        public string Nazwa
        {
            get { return _Nazwa; }
            set
            {
                _Nazwa = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nazwa"));
            }
        }
        private string _Symbol;
        public string Symbol
        {
            get { return _Symbol; }
            set
            {
                _Symbol = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Symbol"));
            }
        }
        private int _id_czesci_symbol;
        public int id_czesci_symbol
        {
            get { return _id_czesci_symbol; }
            set
            {
                _id_czesci_symbol = value;
                PropertyChanged(this, new PropertyChangedEventArgs("id_czesci_symbol"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
