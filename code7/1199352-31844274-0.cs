    public interface IWindowHandler
    {
        View GetCurrentView();
    }
    public class MasterWindowHandler
    {
        public View GetCurrentView()
        {
        }
    }
    public class SomeOtherWindowHandler
    {
    
        public View GetCurrentView()
        {
        }
    }
    // all your windows should inherit from this type
    public class MyBaseWindow : Window
    {
        protected IWindowHander _handler;
        public MyBaseWindow(IWindowHandler handler)
        {
            _handler = handler;
        }
        protected View m_CurrentView = null;
        
        public View CurrentView 
        { 
            get { return m_CurrentView; } 
            set 
            {
                // your code
            }
        } 
    }
    // a sample window code
    public partial class MasterWindow : MyBaseWindow 
    {
        public MasterWindow(IWindowHandler handler) : base(handler)
        {
        }
    }
