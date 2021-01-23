    TestDBEntities context;
    public int SelectedCategoryId { get; set; }
    private void ProductList_Load(object sender, EventArgs e)
    {
        context = new TestDBEntities();
        context.Products.Where(x => x.CategoryId == SelectedCategoryId).ToList();
        this.productBindingSource.DataSource = context.Products.Local;
    }
    
    private void SaveButton_Click(object sender, EventArgs e)
    {
        this.Validate();
        this.productBindingSource.EndEdit();
        context.SaveChanges();
        this.DialogResult = DialogResult.OK;
    }
