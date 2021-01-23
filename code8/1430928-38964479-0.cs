    private string _messageBoxTest;
    
        public string MessageBoxTest
        {
           get{ return _messageBoxTest;}
           set{ _messageBoxTest = value;
               RaisePropertyChange(MessageBoxTest);
              }
        
        }
