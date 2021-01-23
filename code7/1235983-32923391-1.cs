    var sum = this.listView1.Items.Cast<ListViewItem>()
                  .ToList()
                  .Select(item => int.Parse(item.SubItems[2].Text)* 120)
                  .Sum();
    labelItemAmount.Text = sum.ToString();
