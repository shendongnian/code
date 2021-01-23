    // SqlConnection creation and opening omitted
    using(SqlCommand cmd = new SqlCommand("SELECT BImage FROM Bicycle WHERE BID = " + dg1.SelectedRows[0].Cells[0].Value + "", sqlconn))
    {
      byte[] mydata = (byte[])cmd.ExecuteScalar();
      MemoryStream stream = new MemoryStream(mydata);
      BikePic.Image = Image.FromStream(stream);
    }
