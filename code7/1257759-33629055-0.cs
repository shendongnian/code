    dsView = new DataSet();
    adp = new SqlCeDataAdapter(SQL, Conn);
    adp.Fill(dsView, "ROW");
    adp.Dispose();
    foreach (DataRow R in dsROW.Tables[0].Rows)
    {
        ItemCode = R["ItemCode"].ToString().Trim();
        using (var ms = new MemoryStream(R["PIC"]))
        {
            Image image = Image.FromStream(ms);
            image.Save($"C:\\Output\\YourCustomPath\\{ItemCode}.jpeg", ImageFormat.Jpeg); 
        }
    }
