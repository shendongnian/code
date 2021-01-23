     e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
     try
     {
         p.Print();
     }
     catch (Exception ex)
     {
         throw new Exception("Exception Occured While Printing", ex);
     }
