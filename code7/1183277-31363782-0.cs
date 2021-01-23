    abstract class BasePanel : UserControl, IBasePanel  {
        public BasePanel() {
            InitializeComponent();
            RegisterEvents();
        }
    
        public abstract void InitializeComponent(); 
        public abstract void RegisterEvents();
        public abstract void Close();
    }
