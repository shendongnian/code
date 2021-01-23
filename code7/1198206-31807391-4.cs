    m_ButtonCommand= new RelayCommand(Submit, CanSubmit);
    
    now method for this submit:
     private bool CanSubmit(object obj)
            {
                if(thistext available)
                    return true; 
                 else
                    return false;  
    
            }
     public void Submit(object _)
      {//... code}
    
     public event EventHandler CanExecuteChanged {
            add {
                CommandManager.RequerySuggested += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
            }
        }
