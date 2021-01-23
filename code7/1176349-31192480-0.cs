    private void btnSave_Click(object sender, EventArgs e) 
    {
    pictureBox1.Image.Save(@"C:\Temp\test.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
    }
       }
