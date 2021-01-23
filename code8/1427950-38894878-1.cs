    public partial class MainWindow : Window
        {
            static Dispatcher dispatcher = System.Windows.Application.Current.Dispatcher;
            public static void ShowTrayNotification(ToolTipIcon icon, string title, string text)
            {
                if (dispatcher != null && !dispatcher.CheckAccess())
                {
                    dispatcher.Invoke(() => ShowTrayNotification(icon, title, text));
                    return;
                }
                UIHelper.ShowTrayNotification(icon, title, text);
            }
        }
