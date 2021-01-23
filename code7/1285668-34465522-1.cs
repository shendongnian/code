    SampleDbContext db;
    private void Form1_Load(object sender, EventArgs e)
    {
        db = new SampleDbContext();
        db.Products.Load();
        this.productDataGridView.DataSource = db.Products.Local.ToBindingList();
    }
    private void SaveButton_Click(object sender, EventArgs e)
    {
        db.SaveChanges();
    }
