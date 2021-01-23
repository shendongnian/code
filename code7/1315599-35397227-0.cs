        public void Add(Logged user)
        {
            Logged.Add(user);
            UpdateView(); //Check the List for users
            //You dont need this RaisedPropertyChanged
            RaisePropertyChanged("Logged"); //Notify View binding there is a change
        }
