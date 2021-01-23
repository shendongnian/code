    private void Form_Load(object sender, EventArgs e)
    {
        var list = new List<MyModel>();
        list.Add(new MyModel() { Property1 = "Value 1", Property2 = 1, Property3 = false });
        list.Add(new MyModel() { Property1 = "Value 2", Property2 = 2, Property3 = true });
        list.Add(new MyModel() { Property1 = "Value 3", Property2 = 3, Property3 = true });
        this.dataGridView1.DataSource = list;
    }
