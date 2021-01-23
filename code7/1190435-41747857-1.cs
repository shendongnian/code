        DataContext db = new DataContext();
        public SupliersForm()
        {
            InitializeComponent();
            supliersDG.DataSource = db.Supliers.Local.ToBindingList();
            db.Supliers.Load();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            supliersDG.EndEdit();
            db.SaveChanges();
        }
