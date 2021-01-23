            ListView listView1 = new ListView();
            listView1.View = View.Details;
            listView1.Location = new Point(50, 50);
            this.Controls.Add(listView1);
            listView2.Columns.Add("AAA");
            listView2.Columns.Add("BBB");
            listView2.Columns.Add("CCC");
            listView2.Columns.Add("DDD");
            listView2.Columns.Add("EEE");
            ListViewItem item1= new ListViewItem();
            //If the following line is omitted, the 'added row' begins writing in the SECOND cell, not the first
            item1.Text = "0"; //The way to properly set the first piece of a data in a row is with .Text, all other row items are then done with .SubItems
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            listView2.Items.Insert(0, item1); //0 here is the row. Increasing the number, changes which row you are writing data across
