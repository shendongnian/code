    public enumObjectType ObjectType
        {
            get { return objectType; }
            set
            {
                objectType = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ObjectType"));
    
            }
        }
