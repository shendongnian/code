    public static class Util
    {
        public static async Task RunOnUiThread(Action a)
        {
            await Application.Current.Dispatcher.InvokeAsync(() => { a(); });
        }
    }
    
    public partial class MainWindow : Window
    {
        private async Task Write(string message)
        {
            var action = new Action(() =>
            {
                var i = OutputListBox.Items.Count - 1;
                if (i >= 0)
                {
                    OutputListBox.Items[i] = OutputListBox.Items[i] + message;
                }
                else
                {
                    OutputListBox.Items.Add(message);
                }
            });
            await Util.RunOnUiThread(action);
        }
    }
