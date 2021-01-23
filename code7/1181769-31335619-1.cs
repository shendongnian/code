      RelayCommand getitem;
        public RelayCommand GetItem
        {
            get
            {
                if(getitem == null)
                {
                    getitem = new RelayCommand(p=>Executeyourcommand(p));
                }
                return getitem;
            }
        }
      void Executeyourcommand(object parameter)
        {
            // parameter is your CustomerID
           // do your work here
        }
