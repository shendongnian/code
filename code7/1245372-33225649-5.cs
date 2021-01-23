            listView2 = new ListView();
            listView2.View = View.Details;
            listView2.Location = new Point(50, 50);
            listView2.Size = new Size(400, 100);
            this.Controls.Add(listView2);
            listView2.Columns.Add("AAA");
            listView2.Columns.Add("BBB");
            listView2.Columns.Add("CCC");
            listView2.Columns.Add("DDD");
            listView2.Columns.Add("EEE");
            ListViewItem item1 = new ListViewItem();
            item1.Text = "0"; //The way to properly set the first piece of a data in a row is with .Text
            item1.SubItems.Add("1"); //all other row items are then done with .SubItems
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            item1.SubItems.Add("");
            item1.SubItems.Add("");
            ListViewItem item2 = new ListViewItem();
            item2.Text = "00";
            item2.SubItems.Add("11");
            item2.SubItems.Add("22");
            item2.SubItems.Add("33");
            item2.SubItems.Add("");
            item2.SubItems.Add("");
            ListViewItem item3 = new ListViewItem();
            item3.Text = "000";
            item3.SubItems.Add("111");
            item3.SubItems.Add("222");
            item3.SubItems.Add("333");
            item3.SubItems.Add("");
            item3.SubItems.Add("");
            //item1.SubItems.Clear();
            //item1.SubItems.RemoveAt(1);
            listView2.Items.Add(item1);
            listView2.Items.Add(item2);
            listView2.Items.Add(item3);
            //listView2.Items.Insert(2, item1); //0 here is the row. Increasing the number, changes which row you are writing data across
            listView2.Items[0].SubItems[4].Text = "123\rabc";
