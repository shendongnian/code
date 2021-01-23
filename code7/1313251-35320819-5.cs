        if (listView1.SelectedItems.Count > 0)
        {
            this.listView1.Items[0].Focused = true;
            this.listView1.Items[0].Selected = true;
            this.Index = listView1.FocusedItem.Index;
            ListViewItem selectedItem = listView1.SelectedItems[0];
            form3.GetData(listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text, listView1.Items[listView1.FocusedItem.Index].SubItems[1].Text,
                          listView1.Items[listView1.FocusedItem.Index].SubItems[2].Text, listView1.Items[listView1.FocusedItem.Index].SubItems[3].Text);
            DialogResult ans = form3.ShowDialog();
            if (ans == DialogResult.OK)
            {
                listView1.FocusedItem.SubItems[0].Text = form3.Prozz;
                listView1.FocusedItem.SubItems[1].Text = form3.Kolii;
                listView1.FocusedItem.SubItems[2].Text = form3.Cenaa;
                listView1.FocusedItem.SubItems[3].Text = form3.Proff;
            }
        }
