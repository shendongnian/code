    public class WindowService:IWindowService {
         public void ShowWindow(object viewModel){
             var win = new Window {Content = viewModel};
             win.Style = Application.Current.FindResource("MyWindowsStyle") as Style;
             win.Show();
         }
    }
