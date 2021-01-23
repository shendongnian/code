    public class WindowService:IWindowService {
         public void ShowWindow(object viewModel, DataTemplateSelector templateSelector){
             var win = new Window {Content = viewModel};
             win.ContentTemplateSelector = templateSelector;
             win.Show();
         }
    }
