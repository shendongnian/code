    Bitmap bgImage = (Bitmap)Bitmap.FromStream(Document.FormImage);
    
    PictureBox pb = new PictureBox();
    pb.Image = bgImage;
    pb.Size = pb.Image.Size;
    pb.Top = 0;
    pb.Left = 0;
    panel1.Controls.Add(pb);
    
    foreach (FormField field in Document.FormFields)
    {
        TransparentTextbox tb = new TransparentTextbox();   
        tb.Width = (int)Math.Ceiling(field.MaxLineWidth * 96.0);
        tb.Height = 22;
        tb.Font = new Font("Courier", 12);
        tb.BorderStyle = BorderStyle.None;
        tb.Text = "Super Neat!";
        tb.TextChanged += tb_TextChanged;
        tb.Left = (int)Math.Ceiling(field.XValue * 96.0);
        tb.Top = (int)Math.Ceiling(field.YValue * 96.0);
        tb.Visible = true;
    
        Bitmap b = new Bitmap(tb.Width, tb.Height);
        using (Graphics g = Graphics.FromImage(b))
        {
            g.DrawImage(bgImage, new Rectangle(0, 0, b.Width, b.Height), tb.Bounds, GraphicsUnit.Pixel);
            tb.BgBitmap = b;
        }
        panel1.Controls.Add(tb);
    }
