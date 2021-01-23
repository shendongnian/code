    private static Window _wpfEmptyOwnerWindowToPreventMemoryLoss = null;
    
    public Window WpfEmptyOwnerWindowToPreventMemoryLoss()
    {
        if (_wpfEmptyOwnerWindowToPreventMemoryLoss==null)
        {
            _wpfEmptyOwnerWindowToPreventMemoryLoss = new Window();
            _wpfEmptyOwnerWindowToPreventMemoryLoss.Show();
            _wpfEmptyOwnerWindowToPreventMemoryLoss.Hide();
        }
        return _wpfEmptyOwnerWindowToPreventMemoryLoss;
    }
    
    public class WpfSelectFromList : Window
    {
        public WpfSelectFromList()
        {
            Owner = Tools.WpfEmptyOwnerWindowToPreventMemoryLoss();
        }
        public bool Select(...)
        {
            ....
            ShowDialog();
            return ...;
        }
    }
