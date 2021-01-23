    using System.Windows;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using System.Threading.Tasks;
    public static class InfoBox
    {
        public async static Task<MessageDialogResult> ShowMessageAsync(string title, string Message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
        {
             return await ((MetroWindow)(Application.Current.MainWindow)).ShowMessageAsync(title, Message, style, settings);
        }
    }
