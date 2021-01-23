    public class FmtLabel : Label
    {
      public FmtLabel()
      {
        this.Paint += FmtLabel_Paint;
        AutoSize = false;
      }
      public string[] splitters = new string[] { "{", "}" };
      Font boldFont, italicFont;  // could also be properties..
      public Color TextColor{ get; set; }
      SolidBrush textBrush, backBrush;
      public void FmtLabel_Paint(object sender, PaintEventArgs e)
      {
        if (TextColor == System.Drawing.Color.Empty) TextColor = SystemColors.ControlText;
        ForeColor = this.BackColor;
        textBrush = new SolidBrush(TextColor);
        backBrush = new SolidBrush(ForeColor);
        boldFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
        italicFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Italic);
        string[] parts = this.Text.Split(splitters, StringSplitOptions.None);
        float x = 0f;
        e.Graphics.FillRectangle(backBrush, this.ClientRectangle);
        foreach (string p in parts)
        {
            if (p[0] == '1')
            {
                e.Graphics.DrawString(p.Substring(1), boldFont, textBrush, new Point((int)x, 0));
                x += e.Graphics.MeasureString(p.Substring(1), boldFont).Width;
            }
            else if (p[0] == '2')
            {
                e.Graphics.DrawString(p.Substring(1), italicFont, textBrush, new Point((int)x, 0));
                x += e.Graphics.MeasureString(p.Substring(1), italicFont).Width;
            }
            else
            {
                e.Graphics.DrawString(p, this.Font, textBrush, new Point( (int)x, 0));
                x += e.Graphics.MeasureString(p, this.Font).Width;
            }
        }
        this.Width = (int)x;
        textBrush.Dispose();
        backBrush.Dispose();        
        boldFont.Dispose();
        italicFont .Dispose();
      }
    }
