    public class Business
    {
        public string Name { get; set; }
        public bool IsOk { get { return !string.IsNullOrEmpty(Name); } }
    }
    public partial class BusinessForm : Form
    {
        Business business;
        public BusinessForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.business=new Business();
        }
        public Business Business
        {
            get { return business; }
            set { business=value; }
        }
        public bool IsOk { get { return business.IsOk; } }
    }
