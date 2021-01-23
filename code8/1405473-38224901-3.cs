    public class Meeting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Bible Reading Name Properties
        [XmlIgnore]
        public string BibleReadingMainName
        {
            get { return _TFGW.BibleReadingItem.Main.Name; }
            set
            {
                _TFGW.BibleReadingItem.Main.Name = value;
                OnPropertyChanged("BibleReadingMainName");
            }
        }
        [XmlIgnore]
        public string BibleReadingClass1Name
        {
            get { return _TFGW.BibleReadingItem.Class1.Name; }
            set
            {
                _TFGW.BibleReadingItem.Class1.Name = value;
                OnPropertyChanged("BibleReadingClass1Name");
            }
        }
        [XmlIgnore]
        public string BibleReadingClass2Name
        {
            get { return _TFGW.BibleReadingItem.Class2.Name; }
            set
            {
                _TFGW.BibleReadingItem.Class2.Name = value;
                OnPropertyChanged("BibleReadingClass2Name");
            }
        }
        #endregion
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
