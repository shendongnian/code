    public class HaveLoginData
    {
         private IHaveLoginData _regionData; 
         public IHaveLoginData RegionData
         {
              get { return _regionData; }
              set 
              {
                  if (value != null)
                  {
                       value.PropertyChanged += OnRegionDataChanged;
                  }
                  if (_regionData != null)
                  {
                       _regionData.PropertyChanged -= OnRegionDataChanged;
                  }
                  _regionData = value;
                  OnPropertyChanged("RegionData");
              }
         } 
    }
