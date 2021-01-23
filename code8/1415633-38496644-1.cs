    class ViewManager
    {
       public void ShowView<T>(object viewModel) where T: UserControl, new()
       {
           var view = T();
           var window = new Window(); // feel free to prelace this simple approach with hosting shell
           view.DataContext = viewModel;
           window.Content = view;
           window.Show();
       }
    }
