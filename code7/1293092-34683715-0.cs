    RelayCommand _saveCommand;    
    public ICommand SaveCommand    
    {    
       get    
       {    
          if (_saveCommand== null)    
          {    
            _saveCommand= new RelayCommand(p => this.SaveCommand((object)p),    
            p => this.CanDoMyCommand(p) ); // you can set it to true for testing purpose or bind it to a property IsValid if u want to disable the button   
          }    
        return _saveCommand;    
       }
    
    }
    private void SaveCommand(object vm)
    {
    }
