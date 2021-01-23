            private void button1_Click(object sender, EventArgs e)
            {
                listView1.BeginUpdate();
                listView2.BeginUpdate();
    
                var checkedItems = new List<ListViewItem>();
    
                foreach (ListViewItem li in listView1.CheckedItems)
                {
                    checkedItems.Add(li.Clone() as ListViewItem);
                    listView1.Items.Remove(li);
                }
    
                listView2.Items.AddRange(checkedItems.ToArray());
    
                listView1.EndUpdate();
                listView2.EndUpdate();
            }
