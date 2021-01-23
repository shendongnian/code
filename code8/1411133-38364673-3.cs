    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        
        GeneralForm General = new GeneralForm();
    
        ConfigForm Config = new ConfigForm(General); /* you send General */
    
        private void Menu_Load(object sender, EventArgs e)
        {
            //Load of Config Form
            Config.MdiParent = this.MdiParent;
            Config.Show();
    
           //Load of General Form
            General.Show();
            General.TopLevel = false;
            Config.Controls["panel1"].Controls.Add(General);
         }
    }
