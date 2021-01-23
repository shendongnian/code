    public interface IDialogService<T>
    {
        void Show();
        void ShowDialog();
    }
    public class DialogService<T> : IDialogService<T> where T : Window
    {
        public void Show()
        {
            container.Resolve<T>().Show();
        }
        public void ShowDialog()
        {
            container.Resolve<T>().ShowDialog();
        }
    }
