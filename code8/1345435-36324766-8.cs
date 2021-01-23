    protected void onPropertyChanged(string propertyName)
    {
        App.Current.Dispatcher.Invoke(new Action(()=>{ 
            var handler = PropertyChanged;
            if (handler !=null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }));
    }
