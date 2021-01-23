    if (listView1.Items.Count > 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    string delete = "~$";
                    if (item.Text.Contains(delete))
                    {
                        listView1.Items.Remove(item);
                    }
                }
            }
