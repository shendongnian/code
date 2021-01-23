       public int Predict(Image<Gray, Byte> testImage)
            {
    
                Emgu.CV.FaceRecognizer.PredictionResult x;
                if (testImage != null)
                {
                    x= fr.Predict(testImage);
                    pictureBox1.Image = testImage.ToBitmap();
                    //MessageBox.Show(x.Label.ToString()+" "+x.Distance.ToString());
                   
                    OleDbCommand D1 = new OleDbCommand("Select [ID] FROM [connect]", DBConnection);
                    OleDbDataReader reader = D1.ExecuteReader();
                    while (reader.Read())
                    {
    
                       if (Convert.ToInt32(reader["ID"]) == x.Label)
                       {
                          
                           OleDbCommand insert1 = new OleDbCommand("UPDATE OutputReport SET [Attendance]='yes' WHERE [StudentID]='109';", DBConnection);
                          int i= insert1.ExecuteNonQuery();
                          MessageBox.Show(i.ToString());
                       }
                   }
                    RefreshDBConnection();
                   
                    if (x.Distance < 69)
                        return x.Label;
                    else
                        MessageBox.Show("Error!!, The detected Face is neither recognised nor enrolled");
                    return -1;
                }
            
            else
               
            {
                
                return -1;
            }
           
           
        }
       
