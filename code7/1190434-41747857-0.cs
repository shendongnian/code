        DataContext db = new DataContext();
        public SupliersForm()
        {
            InitializeComponent();
            supliersDG.DataSource = db.Supliers.Local.ToBindingList();
            db.Supliers.Load();`enter code here`
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {`enter code here`
            supliersDG.EndEdit();
            db.SaveChanges();
        }
