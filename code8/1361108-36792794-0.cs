    private BindingSource bindingSource1 = new BindingSource();
    private void Form1_Load(object sender, EventArgs e)
    {
        bindingSource1.DataSource = typeof(Model1);
        this.textBox1.DataBindings.Add("Text", bindingSource1, "Property1", true,
                                        DataSourceUpdateMode.OnValidation);
        this.textBox2.DataBindings.Add("Text", bindingSource1, "Property2", true,  
                                        DataSourceUpdateMode.OnValidation);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        bindingSource1.DataSource = GetData();
    }
