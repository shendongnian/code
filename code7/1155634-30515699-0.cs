            for (int c = 0; c < listView1.Items.Count; c++)
            {
                listView1.Items[c].SubItems[0].Text = listView1.Items[c].Text;
                listView1.Items[c].SubItems.Add(c.ToString());
                listView1.Items[c].SubItems[1].Text = c.ToString();
            }
