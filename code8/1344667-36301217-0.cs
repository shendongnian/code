    while (rdr.Read() == true)
    {
      string DestFilePath== @"c:\mytest.bmp";
      int PictureCol = 4; // the column #
      Byte[] b = new Byte[(rdr.GetBytes(PictureCol, 0, null, 0, int.MaxValue))];
      rdr.GetBytes(PictureCol, 0, b, 0, b.Length);
      using(System.IO.FileStream fs = new System.IO.FileStream(DestFilePath, 
                  System.IO.FileMode.Create,System.IO.FileAccess.Write))
      {
	      fs.Write(b, 0, b.Length);
	  }
      dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6],
                                                     Bitmap.FromFile(DestFilePath));
    }
