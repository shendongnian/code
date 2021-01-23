            if (!IsPostBack)
        {
            ListItem li = new ListItem();
            li.Text = "(06) USA";
            li.Value = "01";
            ListItem li2 = new ListItem();
            li2.Text = "(34) ITALY";
            li2.Value = "02";
            ListItem li3 = new ListItem();
            li3.Text = "(06) SPAIN";
            li3.Value = "03";
            ListBox1.Items.Add(li);
            ListBox1.Items.Add(li2);
            ListBox1.Items.Add(li3);
        }
