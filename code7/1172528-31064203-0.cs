    using System.IO;
    using System.Data.OracleClient;
    public void storeImage_Click(string imgPath)
    {
        FileStream fls;
        fls = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
        //a byte array to read the image 
        byte[] blob = new byte[fls.Length];
        fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
        fls.Close();
        
        db.MyClass.Add(blob);
        db.SaveChanges();
    }
