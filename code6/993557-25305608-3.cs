    class ProductCategory
    {
      public int ID {get;set;}
      public string Name {get;set;}
    }
    
    class Product
    {
       public int ID {get;set;}
       public string Name {get;set;}
       public int CategoryID {get;set;}
    }
    
    
    // Example data binding:
    
    BindingList<Products> bl = new BindingList<Products>(State.Instance.Products.ToList());
    BindingSource bs = new BindingSource();
    bs.DataSource=bl;
    
    dataGridView.DataSource = bs;
    
    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    col.DataSource = State.Instance.Categories.ToList();
    col.DataPropertyName = "CategoryID";
    col.DisplayMember= "Name"; // name of category
    col.ValueMember ="ID"; // id of category
