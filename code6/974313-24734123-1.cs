    public partial class ManualEntry : Form
    {
        private Data DataViewData;
        private DataGridView DataView;
        private Point DataViewLocation;
        private Control DataViewParent;
    
        public ManualEntry(DataGridView ExcelDisplay, Data data)
        {
            InitializeComponent();
            this.DataViewData = data;
            this.DataView = ExcelDisplay;
            this.DataViewLocation = ExcelDisplay.Location;
            this.DataViewParent = ExcelDisplay.Parent;
            this.DataView.Parent = this;
            // etc...
        }
    
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (!e.Cancel) {
                DataView.Parent = this.DataViewParent;
                DataView.Location = this.DataViewLocation;
                // etc..
            }
        }
    }
