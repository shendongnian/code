    string stringToPrint = "SOME TEXT TO PRINT";
    StringFormat sf = new StringFormat();
    sf.Alignment = StringAlignment.Center;
    // Create font and brush.
    Font drawFont = new Font("Arial", 16);
    SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Black);
    //Starting point of left margin,Width of page, Height of Text
    System.Drawing.Point rect = new System.Drawing.RectangleF(0, 100, 100, 50); 
    ev.Graphics.DrawString(stringToPrint, drawFont, drawBrush, rect, sf);
    ev.HasMorePages = false;
