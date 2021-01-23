    using System.Data.Entity;
<!---->
    SampleDbEntities db = new SampleDbEntities();
    private void Form1_Load(object sender, EventArgs e)
    {
        db.Configuration.ProxyCreationEnabled = false;
        db.Products.Load();
        this.productsBindingSource.DataSource = db.Products.Local.ToBindingList();
    }
    private void FilterButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.FilterTextBox.Text))
        {
            this.productsBindingSource.DataSource = db.Products.Local.ToBindingList();
        }
        else
        {
            var filteredData = db.Products.Local.ToBindingList()
                .Where(x => x.Name.Contains(this.FilterTextBox.Text));
            this.productsBindingSource.DataSource = filteredData.Count() > 0 ?
                filteredData : filteredData.ToArray();
        }
    }
    private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
        this.Validate();
        productsBindingSource.EndEdit();
        db.SaveChanges();
    }
    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
        if (productsBindingSource.Current != null)
        {
            var current = (Product)this.productsBindingSource.Current;
            this.productsBindingSource.RemoveCurrent();
            if (!string.IsNullOrEmpty(this.FilterTextBox.Text))
                db.Products.Local.Remove(current);
        }
    }
