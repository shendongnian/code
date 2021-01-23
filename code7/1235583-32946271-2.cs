    BindingList<Category> source = new BindingList<Category>();
    private void Form_Load(object sender, EventArgs e)
    {
        //Load Data to BindingList
        new List<Category>()
        {
            new Category(){Id=1, Name= "Category 1"},
            new Category(){Id=2, Name= "Category 2"},
        }.ForEach(x=>list.Add(x));
        this.categoryDataGridView.DataSource = list;
    }
    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        //Add data to BindingList 
        //Data will be visible to grid immediately
        list.Add(new Category(){Id=3, Name= "Category 3"});
    }
