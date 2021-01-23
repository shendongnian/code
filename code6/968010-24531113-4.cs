    public class FmtLabel : Label
    {
        public FmtLabel()
        {
            this.Paint += FmtLabel_Paint;
            Escape = @"\";
            Splitter = "*";
            AutoSize = true;
        }
        public string Splitter    { get; set; }
        public string Escape      { get; set; }
        public Font   StrongFont  { get; set; }
        public Color  StrongColor { get; set; }
        private SolidBrush textBrush, backBrush, strongBrush;
        protected override void OnPaint(PaintEventArgs e) { FmtLabel_Paint(this, e); }
  
        public void FmtLabel_Paint(object sender, PaintEventArgs e)
        {
            if (StrongColor == Color.Empty) StrongColor = SystemColors.ControlText;
            textBrush = new SolidBrush(ForeColor);
            backBrush = new SolidBrush(BackColor);
            strongBrush = new SolidBrush(StrongColor);
            e.Graphics.FillRectangle(backBrush, this.ClientRectangle);
            if (this.Text.Length <= 0) return;
            if (Splitter == null) Splitter = "*";
            int strongStart = Text.StartsWith(Splitter) ? 0 : 1;
            StringFormat SF = new StringFormat(StringFormat.GenericTypographic)
                        { FormatFlags = StringFormatFlags.MeasureTrailingSpaces };
            float x = 0f;  // tracks the write pointer
            string text_ = escapes(this.Text, true);
            string[] parts = text_.Split(new string[] { Splitter }, 
                                         StringSplitOptions.RemoveEmptyEntries);
            // plain and strong text will alternate
            for (int i = 0; i < parts.Length; i++)
            {
               string p = escapes(parts[i], false);
               if (i % 2 == strongStart)
               {
                  e.Graphics.DrawString(p, StrongFont, textBrush, new Point((int)x, 0));
                  x += e.Graphics.MeasureString(p, StrongFont, Point.Empty, SF).Width + 2;
               }
               else
               {
                  e.Graphics.DrawString(p, this.Font, textBrush, new Point((int)x, 0));
                  x += e.Graphics.MeasureString(p, this.Font, Point.Empty, SF).Width + 2;
               }
            }
            this.Width = (int)x;
            textBrush.Dispose();
            backBrush.Dispose();
            strongBrush.Dispose();
        }
        string escapes(string input, bool escape)
        {
            if (escape)  return input.Replace(Escape + Splitter, ((char)1).ToString());
            else         return input.Replace(((char)1).ToString(), Splitter);  // unescape
        }
    }
