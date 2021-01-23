    public class ProfileSegmentType : INotifyPropertyChanged
    {
      public ProfileSegmentType()
      {
        LocalizeDictionary.Instance.PropertyChanged += (e, a) =>
        {
          if (a.PropertyName == "Culture")
            PropertyChanged(this, new PropertyChangedEventArgs("Label"));
        };
      }
      public ProfileSegmentTypeEnum Value { get; set; }
      public string Label
      {
        get { return Common.Resources.Localization.Add; }
      }
      
      public event PropertyChangedEventHandler PropertyChanged = (e, a) => {};
    }
