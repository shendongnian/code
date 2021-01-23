    BindingList<Category> list = new BindingList<Category>();
    private void ChartForm_Load(object sender, EventArgs e)
    {
        list.Add(new Category() { Id = 1, Name = "C1" });
        list.Add(new Category() { Id = 2, Name = "C2" });
        list.Add(new Category() { Id = 3, Name = "C3" });
        this.listBox1.DataSource = list;
        this.listBox1.DisplayMember = "Name";
    }
