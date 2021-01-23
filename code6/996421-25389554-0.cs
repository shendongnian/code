    public abstract partial class ReportsController()
    {
        public ReportsController()
        {
            InitializeComponent();
            //now your method
            Init();
            CheckProperties();            
        }
        protected virtual void CheckProperties()
        {
           if(Table==null)
              addVisualErrorMessage("Table property missing");
           //and so on
        }
        protected abstract void Init();
    }
