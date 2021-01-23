    var temp = table.Clone();
    table.AsEnumerable()
         .OrderByDescending(x => x.ItemArray.OfType<bool>()
             .Select(b => b ? 1 : 0).Sum())
         .ToList().ForEach(x =>
         {
             temp.Rows.Add(x.ItemArray);
         });
    this.dataGridView1.DataSource = temp;
