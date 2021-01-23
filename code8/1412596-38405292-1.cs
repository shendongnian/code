    using(SearchProduct sp = new SearchProduct(this))
    {
        sp.ShowDialog(this);
    }
    //In SearchProduct class
    public BillingForm MyParent {get; private set;}
    public SearchProduct(BillingForm parent)
    {
        this.MyParent = parent;
    }
    private void dataGridView1_KeyDown(object sender,KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BillingForm bf = this.MyParent;
            bf.updatedText("Hello World");
            this.close();
        }
    }
