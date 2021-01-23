    public class Charge : INotifyPropertyChanged
    {
    
      private string chargeSectionNumber;
      public string ChargeSectionNumber
      {
        get
        {
          return chargeSectionNumber;
        }
        set
        {
          if (value != chargeSectionNumber)
          {
            chargeSectionNumber = value;
            NotifyPropertyChanged("ChargeSectionNumber");
          }
        }
      }
    
      private void NotifyPropertyChanged(string info)
      {
        if (PropertyChanged != null)
        {
          PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    }
