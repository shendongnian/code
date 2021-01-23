    using System.Data.Entity;
    //...
    TestDBEntities db = new TestDBEntities();
    private void Form1_Load(object sender, EventArgs e)
    {
        db.Configuration.ProxyCreationEnabled = false;
        db.Products.ToList();
        this.productBindingSource.DataSource = db.Products.Local.ToBindingList();
    }
    private void FilterButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.FilterTextBox.Text))
        {
            this.productBindingSource.DataSource = db.Products.Local.ToBindingList();
        }
        else
        {
            var filteredData = db.Products.Local
                                 .Where(x => x.Name.Contains(this.FilterTextBox.Text));
            this.productBindingSource.DataSource = filteredData;
        }
    }
    private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
        db.SaveChanges();
    }
    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
        db.Products.Local.Remove((Product)this.productBindingSource.Current);
        this.productBindingSource.RemoveCurrent();
    }
