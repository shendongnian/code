    public partial class SODetails : Form
    {
        public IORDR _IORDR { get; set; }
    
        [Inject]
        public SODetails(IORDR ORDR)
        {
            _IORDR = ORDR;
            InitializeComponent();
        }
    
        public SODetails()
        {
