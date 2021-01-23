    public class ProductionWindowFactory: IWindowFactory
    {
    
        #region Implementation of INewWindowFactory
    
        public void CreateNewWindow(AViewModel newWindowViewModel) 
        {
           NewWindow window = new NewWindow()
               {
                   DataContext = newWindowViewModel;
               };
           window.Show();
        }
    
        #endregion
    }
