    public class GameEngin:INotifyPropertyChanged
    {
        private int _life;
   
        public int Life
        {
            get
            {
                return _life;
            }
            set
            {
                _life = value;
                OnProperyChanged("Life")
            }
        }
    
        public GameEngine()
        {
            this.Life = 3; // For Test
        }
    
        //---------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnProperyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                var handler= PropertyChanged ;
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
