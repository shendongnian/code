    RadGridView1.Rows.AddNew();
     RadGridView1.Rows[RadGridView1.Rows.Count - 1].Cells["Data1"].Value = byteArrayToImage(your Byte Array)
    //My First Column(Data1) is ImageColumn.
    public Image byteArrayToImage(byte[] byteArrayIn)
    {
         MemoryStream ms = new MemoryStream(byteArrayIn);
         Image returnImage = Image.FromStream(ms);
         return returnImage;
    }
