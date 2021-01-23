    var jmn = new DataTable("respdoc");
    jmn.Columns.Add("name");
    jmn.Columns.Add("userid");
    foreach (var item in respdoc.Descendants("item"))
    {
        // ...
        jmn.Rows.Add((string)item);
        // ...
    }
    dataGridView1.DataSource = jmn;
