                 private void frmImageSelection_Load(object sender, EventArgs e)
        {
            items = new ListViewItem[listimages.Items.Count];
            listimages.Items.CopyTo(items, 0);
            ShowGroup(0);
            cmbgroups.SelectedIndex = 0;
        }
                private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowGroup(cmbgroups.SelectedIndex);
        }
        void ShowGroup(int index)
        {
            if (index == 0) // all
            {
                listimages.Items.Clear();
                listimages.Items.AddRange(items);
            }
            else
            {
                listimages.Items.Clear();
                foreach (ListViewItem item in items)
                    if (listimages.Groups[index].Name.Equals(item.Tag))
                        listimages.Items.Add(item);
            }
            foreach (ListViewItem item in listimages.Items)
                item.Group = listimages.Groups[index];
        }
        ListViewItem[] items;
