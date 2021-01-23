    class Class_Wall_NPC : INotifyPropertyChanged
    {
        public Class_Wall_NPC()
        {
            standard_Brick.PropertyChanged += InnerUpdate;
        }
        #region Event Methods
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void InnerUpdate(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "NumberOfHoles")
            {
                OnPropertyChanged("NumberOfHoles");
            }
            else if (args.PropertyName == "NumberOfCracks")
            {
                OnPropertyChanged("NumberOfCracks");
            }
        }
        #endregion
        #region Inner Properties
        private ObservableCollection<Class_Brick_NPC> bricks = new ObservableCollection<Class_Brick_NPC>();
        private Class_Brick_NPC standard_Brick = new Class_Brick_NPC();
        private int numberOfHoles = 0;
        private int numberOfCracks = 0;
        #endregion
        #region Properties
        public ObservableCollection<Class_Brick_NPC> Bricks
        {
            get { return bricks; }
            set
            {
                bricks = value;
                                
                OnPropertyChanged("Bricks");
            }
        }
        public Class_Brick_NPC Standard_Brick
        {
            get { return standard_Brick; }
            set
            {
                standard_Brick = value;
            }
        }
        public int NumberOfHoles
        {
            get
            {
                int wallHoles = standard_Brick.NumberOfHoles;
                foreach (Class_Brick_NPC brick in bricks)
                {
                    wallHoles += brick.NumberOfHoles;
                }
                return wallHoles;
            }            
        }
        public int NumberOfCracks
        {
            get
            {
                int wallCracks = standard_Brick.NumberOfCracks;
                
                foreach (Class_Brick_NPC brick in bricks)
                {
                    wallCracks += brick.NumberOfCracks;                    
                }
                return wallCracks;
            }            
        }
        #endregion
        #region Methods
        public void Add_Brick(Class_Brick_NPC addedItem)
        {
            bricks.Add(addedItem);
            addedItem.PropertyChanged += InnerUpdate;
            OnPropertyChanged("Bricks");
        }
        public void Remove_Brick(Class_Brick_NPC removedItem)
        {
            bricks.Remove(removedItem);
            removedItem.PropertyChanged -= InnerUpdate;
            OnPropertyChanged("Bricks");
            OnPropertyChanged("NumberOfHoles");
            OnPropertyChanged("NumberOfCracks");
        }
        #endregion
    }
