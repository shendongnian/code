    public int Predict(Image<Gray, Byte> testImage)
            {
    Emgu.CV.FaceRecognizer.PredictionResult x;
      if (testImage != null)
     {
       x = fr.Predict(testImage);
      pictureBox1.Image = testImage.ToBitmap();
     //MessageBox.Show(x.Label.ToString()+" "+x.Distance.ToString());
      if (x.Distance < 69)
        return x.Label;
     else
    {
     MessageBox.Show("Error!!, The detected Face is neither recognised nor enrolled");
      return -1;
    }
    
    OleDbCommand  D1 = new new OleDbCommand("Select [ID] FROM [connect]",
                                                            DBConnection);
      OleDbDataReader reader = D1.ExecuteReader();
      while (reader.Read())
     {
      
      if (int.Parse(reader["ID"]) == x.Label) 
      {
       OleDbCommand insert1 = new OleDbCommand("Insert INTO OutputReprt
                     (Attendance) values (yes)", DBConnection);
       } 
    
     }
                
