    public string Animal //<----Should Be AnimalName!
    {
        get { return _animal.Name; }
        set
        {
            if (value != this._animal.Name)
            {
                this._animal.Name = value;
                OnPropertyChanged("AnimalName");
            }
        }
    }
