    public class OperationCommand : ICommand
    {
    
    #region Variables
    
    Func<object, bool> canExecute;
    Action<object> executeAction;
    
    public event EventHandler CanExecuteChanged;
    
    #endregion
    
    #region Properties
    
    #endregion
    
    #region Construction/Initialization
    
    public OperationCommand(Action<object> executeAction)
        : this(executeAction, null)
    {
    }
    
    public OperationCommand(Action<object> executeAction, Func<object, bool> canExecute)
    {
        if (executeAction == null)
        {
            throw new ArgumentNullException("Execute Action was null for ICommanding Operation.");
        }
        this.executeAction = executeAction;
        this.canExecute = canExecute;
    }
    
    #endregion
    
    #region Methods
    
    public bool CanExecute(object parameter)
    {
        bool result = true;
        Func<object, bool> canExecuteHandler = this.canExecute;
        if (canExecuteHandler != null)
        {
            result = canExecuteHandler(parameter);
        }
    
        return result;
    }
    
    public void RaiseCanExecuteChanged()
    {
        EventHandler handler = this.CanExecuteChanged;
        if (handler != null)
        {
            handler(this, new EventArgs());
        }
    }
    
    public void Execute(object parameter)
    {
        this.executeAction(parameter);
    }
    
    #endregion
    
    }
