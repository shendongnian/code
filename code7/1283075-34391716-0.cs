    public string Chat
        {
            get { return chat; }
            set
            {
                chat = value;
                RaisePropertyChanged(() => Chat);
            }
        } 
