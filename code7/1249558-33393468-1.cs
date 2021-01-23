    public interface IWindowService
    {
        void OpenView(object viewModel);
    }
    public class WindowService
    {
        public void OpenView(object viewModel)
        {
            //Use reflection to get the view based on the view model name.
            //Open the view
            //Set the DataContext to be the view model.
        }
    }
