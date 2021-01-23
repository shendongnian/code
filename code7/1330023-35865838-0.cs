    var list = new List<int>() { 1, 2, 3, 4, 5 };
    for (int i = 0; i < 10; i++)
    {
        var c = new ComboBox();
        //Option 1
        var bs = new BindingSource();
        bs.DataSource = list;
        c.DataSource = bs;
        //Option 2
        //c.DataSource = list.ToList();
        this.flowLayoutPanel1.Controls.Add(c);
    }
