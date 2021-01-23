    public interface IDialogService
    {
        MessageBoxResult ShowMessageBox(string messageBoxText, string caption = null, MessageBoxButton buttons = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None);
    }
    public class DialogService : IDialogService
    {
        public virtual MessageBoxResult ShowMessageBox(string messageBoxText, string caption = null, MessageBoxButton buttons = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None)
        { 
           return MessageBox.Show(messageBoxText, caption, buttons, icon, defaultResult);
        }
    }
