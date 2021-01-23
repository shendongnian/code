    otherClassObj.PropertyChanged += OtherClassPropertyChanged()
    
    private void OtherClassPropertyChanged(Obj sender, PropertyChangedEventargs e)
    {
      if(e.PropertyName = "DataSource")
      {
        OnDataBound();
      }
    }
