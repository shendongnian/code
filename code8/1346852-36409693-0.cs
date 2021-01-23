    class Class_Brick_NPC : INotifyPropertyChanged
    {
        public Class_Brick_NPC()
        {
        }
        #region Event Functions
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        #region Inner Parametres
        private int numberOfHoles = 0;
        private int numberOfCracks = 0;
        #endregion
        #region Parametres
        public int NumberOfHoles
        {
            get { return numberOfHoles; }
            set
            {
                numberOfHoles = value;
                OnPropertyChanged("NumberOfHoles");
            }
        }
        public int NumberOfCracks
        {
            get { return numberOfCracks; }
            set
            {
                numberOfCracks = value;
                OnPropertyChanged("NumberOfCracks");
            }
        }
        #endregion
    }
