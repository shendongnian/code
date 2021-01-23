    private ICommand _EditImageCommand;
    public ICommand EditImageCommand // has to be public
       {
          get
            {
               return _EditImageCommand ?? (_EditImageCommand = new CommandHandler(() => EditImage(), _canExecute));
            }
       }
    
     public void EditImage()
     {
    
     }
