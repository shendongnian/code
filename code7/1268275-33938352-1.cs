    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        var hs = (HatchStyle[])Enum.GetValues(typeof(HatchStyle));
        
        for (int i = 0; i < hs.Length; i++)
            using (HatchBrush hbr = new HatchBrush(hs[i], Color.GreenYellow))
            using (HatchBrush hbr2 = new HatchBrush(hs[i], Color.LightCyan))
            {
                e.Graphics.FillRectangle(hbr, new Rectangle(i * 20, 10,16,60));
                using (TextureBrush tbr = TBrush(hbr2))
                {
                    e.Graphics.FillRectangle(tbr, new Rectangle(i * 20, 80, 16, 60));
                    tbr.ScaleTransform(2, 2);
                    e.Graphics.FillRectangle(tbr, new Rectangle(i * 20, 150, 16, 60));
                    tbr.ResetTransform();
                    tbr.ScaleTransform(3,3);
                    e.Graphics.FillRectangle(tbr, new Rectangle(i * 20, 220, 16, 60));
                }
            }
    }
