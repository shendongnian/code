    private bool _selected;
    public bool Selected
    {
       get{ return _selected;}
       set
       {
           if(value!=_selected)
           {
               _selected=value;
               OnPropertyChanged("Selected");
               OnPropertyChanged("SelectedImage");
           }
       }
    }
   
    private void OnPropertyChanged([CallerMemberName] string propertyName="")
    {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    }
