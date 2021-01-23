        //without saving the image to a physical file
        MemoryStream stream=new MemoryStream();
    pictureBox1.Image.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);
        
    byte[] pic=stream.ToArray(); 
    
    SqlCommand sqlCommand = new SqlCommand("INSERT INTO imageTest (pic_id, pic) VALUES (1, @Image)", yourConnectionReference);
    sqlCommand.Parameters.AddWithValue("@Image", image);
    sqlCommand.ExecuteNonQuery();
