    foreach (Area area in areaList)
    {
        BindingSource bs = new BindingSource();
        bs.DataSource = area;
        Button btn = new Button();
        btn.AutoSize = false;
        btn.Width = 100;
        btn.BringToFront();
        btn.Height = 35;
        btn.Font= new Font("Arial", 16, FontStyle.Bold);
        btn.BackColor = Color.White;
        btn.FlatStyle = FlatStyle.Flat;
        btn.TextAlign = ContentAlignment.MiddleCenter;
        btn.Margin = new Padding(3,5,3,5);
        btn.DataBindings.Add(new Binding("Text", bs,"Name",false, DataSourceUpdateMode.OnPropertyChanged));
        btn.Click += new EventHandler(btnAreaClick);
        fpnlAreas.Controls.Add(btn);
    }
