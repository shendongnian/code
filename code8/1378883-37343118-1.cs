    public YourClass
    {    
        string name1 = String.Empty:
    
        //..... your code
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.Title = "Select User Profile Image";
            ofd1.Filter = "Image File(*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif";
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd1.FileName);
                name1 = ofd1.FileName;
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
           Compare(name1,name2);
        }
    
        public void Compare(string bmp1, string bmp2, byte threshold = 3)
        {
            Bitmap firstBmp = (Bitmap)Image.FromFile(bmp1);
            Bitmap secondBmp = (Bitmap)Image.FromFile(bmp2);
            firstBmp.GetDifferenceImage(secondBmp, true);
            string result = string.Format("Difference: {0:0.0} %", firstBmp.PercentageDifference(secondBmp, threshold) * 100);
        }
    }
