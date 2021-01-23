    public class ComplexProperties
    {
      public string Table{ get; set; }
      public string Fields{ get; set; }
      public string Condition{ get; set; }
      public string Group{ get; set; }
      public string Order{ get; set; }
      public DataGridViewColumnCollection Columns{ get; set; }
      public SortedList<string, string> ComboboxFields{ get; set; }
    }
    
    public abstract partial class ReportsController()
    {
        public ComplexProperties Properties {get; private set;}
        public ReportsController()
        {
            InitializeComponent();
            //now your method
            Properties= Init();
            CheckProperties(); 
        }
        protected abstract ComplexProperties Init();
    }
