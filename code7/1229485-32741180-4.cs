    public class OpenWindowCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            TypeInfo p = (TypeInfo)parameter;
            return p.BaseType == typeof(Window);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("TargetWindowType");
            //Get the type.
            TypeInfo p = (TypeInfo)parameter;
            Type t = p.BaseType;
            if (p.BaseType != typeof(Window))
                throw new InvalidOperationException("parameter is not a Window type");
            //Create the window.
            Window wnd = Activator.CreateInstance(t) as Window;
            OpenWindow(wnd);
        }
        protected virtual void OpenWindow(Window wnd)
        {
            wnd.Show();
        }
    }
