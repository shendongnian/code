            int value = int.Parse(listView1.Items[index].SubItems[1].Text) +1;
            listView1.Items.RemoveAt(index);
            listView1.Items.Insert(index,
                new ListViewItem(new[]
                {
                    index.ToString(),
                    value.ToString()
                }));
