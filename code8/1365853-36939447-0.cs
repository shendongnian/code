    public class ProductionWindowFactory: IWindowFactory
    {
    
        #region Implementation of INewWindowFactory
    
        public void CreateNewWindow()
        {
           NewWindow window = new NewWindow()
               {
                   DataContext = new NewWindowViewModel()
               };
           window.Show();
        }
    
        public void CreateNewWindow(ViewModel newWindowViewModel) // *new*
        {
           NewWindow window = new NewWindow()
               {
                   DataContext = newWindowViewModel
               };
           window.Show();
        }
    
        #endregion
    }
