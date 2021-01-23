    public interface IDialogWindowService<T>
    {
        void Show();
        void ShowDialog();
    }
    
    public class DialogWindowService<T> : IDialogWindowService<T> where T : Window
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
	
