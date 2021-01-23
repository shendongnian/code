    var imageConverter = new ImageConverter();
    var b1 = (byte[])imageConverter.ConvertTo(Properties.Resources.Image1, typeof(byte[]));
    var b2 = (byte[])imageConverter.ConvertTo(Properties.Resources.Image2, typeof(byte[]));
    var dt = new DataTable();
    dt.Columns.Add("Column1", typeof(byte[]));
    dt.Rows.Add(b1);
    dt.Rows.Add(b2);
    this.dataGridView1.DataSource = dt;
