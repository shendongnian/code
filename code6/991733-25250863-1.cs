    var y = tb.AsEnumerable()
        .GroupBy(row => listView2.Items.Cast<ListViewItem>()
            .Select(item => row[item.Text]), new SequenceComparer<object>())
        .Select(group => new
        {
            Values = group.Key,
            Total = group.Sum(s => s.Field<double>(listView3.Items[0].Text)),
        });
