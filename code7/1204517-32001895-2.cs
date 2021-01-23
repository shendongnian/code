    for (int i = 0; i < itemLis.Length; i++)
    {
        itemDetails = itemsWS.getItemInfo(itemLis[i].ToString());
        Button myButtons = new Button();
        myButtons.Tag = i;
        myButtons.Click += (sender, args) =>
        {
             var button = sender as Button;
             dataGridView1.ColumnCount = 11;
             dataGridView1.Columns[0].Name = "Item Code";
             dataGridView1.Columns[1].Name = "Description";
             dataGridView1.Columns[2].Name = "Sale Price";
             dataGridView1.Columns[3].Name = "Category";
             dataGridView1.Columns[4].Name = "Type";
             dataGridView1.Columns[5].Name = "Status";
             dataGridView1.Columns[6].Name = "Low Count";
             dataGridView1.Columns[7].Name = "Medium Count";
             dataGridView1.Columns[8].Name = "High Count";
             dataGridView1.Columns[9].Name = "Item Picture";
             dataGridView1.Columns[10].Name = "TEST";
             
             dataGridView1.Rows.Add(itemsWS.getItemInfo(itemLis[(int)button.Tag].ToString()));
             
             MessageBox.Show("data grid displayed!");
        };
        myButtons.Text = itemDetails[1].ToString() + "\n  " + itemDetails[2].ToString();
        myButtons.Top = cleft * 180;
        myButtons.Left = 70;
        myButtons.Location = new Point(xs, clefts);
        myButtons.Size = new Size(100, 60);
        tabPage1.Controls.Add(myButtons);
        xs += 135;
        if (xs >= 537)
        {
           xs = 35;
           clefts += 80;
        }
