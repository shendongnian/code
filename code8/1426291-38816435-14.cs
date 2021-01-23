    public class GridRowItemViewModel : ObservableViewModelBase // From previous example.
    {
          private string _sampleProp;          
          public string SampleProp
          {
              get
              {
                  return _sampleProp;
              }
              set
              {
                  _sampleProp = value;
                  OnPropertyChanged();
              }
          }
    }
