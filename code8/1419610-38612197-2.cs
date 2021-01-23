    private ICommand _EditImageCommand;
    private ICommand EditImageCommand
       {
          get
            {
               return _EditImageCommand ?? (_EditImageCommand = new CommandHandler(() => EditImage(), _canExecute));
            }
       }
    
     public void EditImage()
     {
    
     }
