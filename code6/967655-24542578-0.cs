        int i = 0;
        List<Image> Images = new List<Image>();
    private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Images.Add(Clipboard.GetImage());
                
                foreach (Image item in Images)
                {
                    e.Graphics.DrawImage(item, new Point(i,0));
                    i += Clipboard.GetImage().Width;
                    
                }
            }
            i = 0;
         }
