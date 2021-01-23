    public enum MessageType
    {
        None = 0,
        Error = 16,
        Stop = Error,
        Hand = Error,
        Question = 32,
        Warning = 48,
        Exclamation = Warning,
        Information = 64,
        Asterisk = Information
    }
    
    public static class DialogHelper
    {
        public static bool? ShowMessage(string text, string title, MessageType messageType = MessageType.None)
        {
            var dlg = new ModernDialog();
            dlg.Buttons = new[] {dlg.OkButton};
            dlg.Title = title;
            dlg.Content = text;
            dlg.BackgroundContent = new DialogBackgroundContent(messageType);
            dlg.MinWidth = dlg.MinWidth + 200;
    
            bool? res = false;
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => res = dlg.ShowDialog()));
            return res;
        }
    }
