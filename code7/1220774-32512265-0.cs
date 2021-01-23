    public class DesignTimeSampleModel
      {
        public ObservableCollection<SampleModel> SampleList { get; set; }
    
        public DesignTimeSampleModel()
        {
          SampleList = new ObservableCollection<SampleModel>();
          for (int i = 0; i < 10; i++)
          {
            SampleList.Add(new SampleModel()
            {
              Name = "Design Data",
              Image = new Uri("ms-appx:///Assets/StoreLogo.png", UriKind.Absolute)
            });
          }
        }
      }
