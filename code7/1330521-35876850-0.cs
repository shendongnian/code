    List<string> list = new List<string>() { "Add","Sub","Mul","Div"};
    for (int i = 0; i < 10; i++)
    {
        var c = new ComboBox();
        c.Items.AddRange(list.ToArray());
        c.SelectedIndex = 1;
        this.flowLayoutPanel1.Controls.Add(c);
    }
