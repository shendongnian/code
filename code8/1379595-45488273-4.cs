         public class TestViewModel : ViewModelBase   {
            private bool _IsInvalid;
            public bool IsInvalid
            {
              get { return _IsInvalid; }
              set { SetProperty(ref _IsInvalid, value); }
            }
        
            private string _TextValue;
            public string TextValue
            {
              get
              {
                return _TextValue;
              }
              set
              {
                if (SetProperty(ref _TextValue, value))
                {
                  Validate(_TextValue);
                }
              }
            }
        
            private void Validate(string text)
            {
              if (text == "Valid")
              {
                IsInvalid = false;
              }
              else
              {
                IsInvalid = true;
              }
            }   
    }
