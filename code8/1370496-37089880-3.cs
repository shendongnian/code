    public partial class Form5 : Form
    {
        centrEntities db;
        public Form5()
        {
            InitializeComponent();
            FillCombobox();
            comboService.SelectedIndexChanged += new EventHandler(comboService_SelectedIndexChanged);
        }
    
        private void Form5_Load(object sender, EventArgs e)
        {
            db = new centrEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            orderBindingSource.DataSource = db.order.ToList();
        }
    
        private void FillCombobox()
        {
            using (centrEntities c = new centrEntities())
            {
                comboService.DataSource = c.service.ToList();
                comboService.ValueMember = "serviceID";
                comboService.DisplayMember = "name";
            }
        }
    
        private void comboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboService.SelectedValue != null)
            {
                using (centrEntities c = new centrEntities())
                {
                    var price = (from serv in c.service
                                 where serv.serviceID.Equals(Convert.ToInt32(comboBox1.SelectedValue))
                                 select serv.price).SingleOrDefault();
    
                    TextPriceName.Text = price.ToString();
                }
            }
        }
    }
