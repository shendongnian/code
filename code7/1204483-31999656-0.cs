    IEnumerable<string> common =
            Enumerable
                .Intersect(
                    listView1.Items.Cast<ListViewItem>().Select(x => x.Text),
                    listView2.Items.Cast<ListViewItem>().Select(x => x.Text));
    IEnumerable<string> all =
            Enumerable
                .Union(
                    listView1.Items.Cast<ListViewItem>().Select(x => x.Text),
                    listView2.Items.Cast<ListViewItem>().Select(x => x.Text));
    IEnumerable<string> unique = all.Except(common);
