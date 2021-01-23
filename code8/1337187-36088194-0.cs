    public class myClass :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void ChangeCell()
        {
            PropertyChanged(this,new PropertyChangedEventArgs("CellGiorno1")
        }
        public int CellGiorno1
        {
            get
            {
                int a = myfunctionexample(day, Username, month, year);
                return a;
                //return 0-1-2
            }
        }
    }
