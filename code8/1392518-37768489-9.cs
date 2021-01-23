    var temp = table.Clone();
    table.Rows.Cast<DataRow>()
         .OrderByDescending(x => x.ItemArray.OfType<bool>().Count(b=>b==true))
         .ToList().ForEach(x =>
         {
             temp.Rows.Add(x.ItemArray);
         });
    this.dataGridView1.DataSource = temp;
