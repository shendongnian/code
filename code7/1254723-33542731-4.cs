    private void button_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(picFP.ClientSize.Width, picFP.ClientSize.Height);
        Graphics G = Graphics.FromImage(bmp);
        IntPtr dc= G.GetHdc();
        objNitgen = dc;
        objNitgen.capture();
        G.ReleaseHdc(dc);
        pictureBox1.Image = bmp;  // now display..
        bmp.Save(yourfilename);   // .. and/or save
    }
