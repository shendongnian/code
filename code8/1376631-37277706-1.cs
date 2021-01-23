        get { return _volume; }
        set
        {
            // prevent any event firing if nothing changed
            if( _volume == value )
            {
                return;
            }
            // now we can set
            _volume = value;
            // something really changed, fire some event
            this.NotifyPropertyChanged();
        }
    }
