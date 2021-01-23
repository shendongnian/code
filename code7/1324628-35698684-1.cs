    DataTable userTable;
    DataTable ds;
    
    int cin;
    string nom;
    string prenom;
    Byte[] ImageByte;
    
    userTable = ds;
    if (userTable == null)
    	return false;
    else
    {
    	if (userTable.Rows.Count > 0)
    	{
    		foreach (DataRow userRow in userTable.Rows)
    		{
    			cin = Convert.ToInt32(userRow["cin"]);
    			nom = userRow["nom"].ToString();
    			prenom = userRow["prenom"].ToString();
    			ImageByte = (Byte[])(userRow["image"]);
    		}
    	}
    }
    if (ImageByte != null)
    {
    	// You need to convert it in bitmap to display the imgage
    	pictureBox1.Image = ByteToImage(ImageByte);
    	pictureBox1.Refresh();
    }
    
    public static Bitmap ByteToImage(byte[] blob)
    {
    	MemoryStream mStream = new MemoryStream();
    	byte[] pData = blob;
    	mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
    	Bitmap bm = new Bitmap(mStream, false);
    	mStream.Dispose();
    	return bm;
    
    }
