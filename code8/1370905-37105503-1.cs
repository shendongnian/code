    private void button2_Click(object sender, EventArgs e)
    {
      
       
            Image img = picturebox.Image;
            byte[] imgbyte= ImageToByte(img);
            InsertImageintoSqlDatabaseAsBinary(imgbyte);
        
        }
