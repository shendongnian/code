    private BaseCommand _mouseClick;
    public BaseCommand MouseClick
    {
       get
       {
         if (null == _mouseClick)
                    {
                       _mouseClick = new BaseCommand(CanExecuteCommand, OpenDocument);
                    }
                    return _open;
       }
    }
    
     private bool CanExecuteCommand(object obj)
            {
                return true; //for example
            }
    
     public void MouseClickCommand(object o)
    {
    //do something
    }
