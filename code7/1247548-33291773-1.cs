        private void button1_Click(object sender, EventArgs e)
        {
          using (PrintDocument pd = new PrintDocument())
          {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = @"C:\image.JPG";
                pd.OriginAtMargins = true;
                pd.PrintPage += pd_PrintPage;
                pd.DocumentName = filePath;
                pd.Print();
                pd.PrintPage -= pd_PrintPage;
            }
          }
        }
        public void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string labelPath = ((PrintDocument)sender).DocumentName;
            e.Graphics.DrawImage(new Bitmap(labelPath), 0, 0);
        }
