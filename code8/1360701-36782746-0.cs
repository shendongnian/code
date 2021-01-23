    byte[] bytearray = null;
                using (var fs = new FileStream("C:\\1\\bears.jpg", FileMode.Open))
                    {
                    //fs.Seek(0, SeekOrigin.Begin);
                    bytearray = new byte[fs.Length];
                    fs.Write(bytearray,0, (int)fs.Length);
                    fs.Close();
                    }
    
                MemoryStream ms = new MemoryStream(bytearray);
                pictureBox1.Image = Image.FromStream(ms);
