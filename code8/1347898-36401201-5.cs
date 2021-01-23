    public class YourViewModel
    {
        private readonly IWindowFactory windowFactory;
        private ICommand openNewWindow;
    
        public YourViewModel(IWindowFactory _windowFactory)
        {
            windowFactory = windowFactory;
    
            /**
             * Would need to assign value to m_openNewWindow here, and 
             * associate the DoOpenWindow method
             * to the execution of the command.
             * */
            openNewWindow = null;  
        }
    
        public void DoOpenNewWindow()
        {
            windowFactory.CreateNewWindow();
        }
    
        public ICommand OpenNewWindow { get { return openNewWindow; } }
    }
    
    public interface IWindowFactory
    {
        void CreateNewWindow();
    }
    
    public class ProductionWindowFactory: IWindowFactory
    {
    
        #region Implementation of INewWindowFactory
    
        public void CreateNewWindow()
        {
           NewWindow window = new NewWindow
               {
                   DataContext = new NewWindowViewModel()
               };
           window.Show();
        }
    
        #endregion
    }
