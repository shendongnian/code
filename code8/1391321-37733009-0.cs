        private void button1_Click(object sender, EventArgs e)
        {
            var checkedItems = new List<ListViewItem>();
    
            foreach (ListViewItem li in listView1.CheckedItems)
            {
                checkedItems.Add(li.Clone() as ListViewItem);
                listView1.Items.Remove(li);
            }
    
            listView2.Items.AddRange(checkedItems.ToArray());
        }
