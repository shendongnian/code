     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<JobCostEntity> l = new List<JobCostEntity>()
            {
                new JobCostEntity() {Id = 0, InvoiceDate = DateTime.Now, Description = "A"},
                new JobCostEntity() {Id = 0, InvoiceDate = DateTime.Now, Description = "B"}
            };
            dg.ItemsSource = l;
        }
        private void dg_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            //MessageBox.Show("AddingNewItem");
        }
    }
    public partial class JobCostEntity : INotifyPropertyChanged
    {
        private string _description;
        private DateTime? _invoiceDate;
        public int Id { get; set; }
        public int JobId { get; set; }
        public Nullable<int> JobItemId { get; set; }
        public Nullable<System.DateTime> InvoiceDate
        {
            get { return _invoiceDate; }
            set
            {
                if (value.Equals(_invoiceDate)) return;
                _invoiceDate = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> ProcessedDate { get; set; }
        public int PackageId { get; set; }
        public int DelegateId { get; set; }
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }
        public Nullable<decimal> LabourCost { get; set; }
        public Nullable<decimal> PlantOrMaterialCost { get; set; }
        public Nullable<decimal> SubcontractorCost { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public bool Paid { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
   
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
