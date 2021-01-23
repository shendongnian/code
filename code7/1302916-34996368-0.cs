       public class RelayCommand : ICommand
    {
    public RelayCommand()
    {}
    private readonly Action<object> _Execute;
    private readonly Func<object, bool> _CanExecute;
    public RelayCommand(Action<object> execute)
        : this(execute, null)
    {
    }
