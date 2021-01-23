    private ICommand m_MouseDownCommand;
    private ICommand m_MouseMoveCommand;
    private ICommand m_MouseUpCommand;
    private bool CanMove
    private Point center; // binded to the center property of EllipseGeometry in View.
    
    public Point Center
    {
       get
       {
         return center;
       }
       set
       {
         center = value;
         OnPropertyChanged(nameof(Exemple));
       }
    }
    
    // first parameter is the method that handle the event, the second is a bool method that define if the event is triggerable.
    // DelegateCommand is a custom class implementing ICommand, i'll give code below.
    
    public ICommand MouseDownCommand => m_MouseDownCommand ?? (m_MouseDownCommand = new DelegateCommand(OnMouseDown, CanMouseDown));
    
    public ICommand MouseMoveCommand => m_MouseMoveCommand ?? (m_MouseMoveCommand = new DelegateCommand(OnMouseMove, CanMouseMove));
        
    public ICommand MouseUpCommand => m_MouseUpCommand ?? (m_MouseUpCommand = new DelegateCommand(OnMouseUp, CanMouseUp));
        
        
    private bool CanMouseDown(object parameter)
    {
       return true;
    }
        
    private bool CanMouseMove(object parameter)
    {
       return CanMove;
    }
        
    private bool CanMouseUp(object parameter)
    {
       return true;
    }
        
    private void OnMouseDown(object parameter)
    {
       CanMove = true;
    }   
                   
        
    private void OnMouseMove(object parameter)
    {
       // EllipseGeometry Center property is updated !
       Center = Mouse.GetPosition((IInputElement)parameter);
    }
    
    
    private void OnMouseUp(object parameter)
    { 
       CanMove = false;
    }   
      
                
                 
