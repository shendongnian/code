    public class WindowService : IWindowService
    {
        public void ShowDialog<T>(ViewModelBase viewModel) where T : IApplicationDialog
        {
            IApplicationDialog dialog = (IApplicationDialog)Activator.CreateInstance(typeof(T));
            dialog.Show();
        }
    }
