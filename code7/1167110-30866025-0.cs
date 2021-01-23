    PdfPage pdfpage;
    XGraphics xGrap;
    XTextFormatter textformater;
    
    //Create Fonts
    XFont titlefont = new XFont("Calibri", 20, XFontStyle.Regular);
    XFont tableheader = new XFont("Calibri", 15, XFontStyle.Bold);
    XFont bodyfont = new XFont("Calibri", 11, XFontStyle.Regular);
    
    //Draw the text
    double x = 0;
    double y = 50;
    //Title Binding
    
    int index = 0;
    foreach (var item in data)
    {
        if (index % 30 == 0)
        {
            y = 50;
            x = 0;
            // Start a new page.
            //Create an Empty Page
            pdfpage = outputDocument.AddPage();
            pdfpage.Size = PageSize.Letter; // Change the Page Size
            pdfpage.Orientation = PageOrientation.Landscape;// Change the orientation property
    
            //Get an XGraphics object for drawing
            xGrap = XGraphics.FromPdfPage(pdfpage);
            textformater = new XTextFormatter(xGrap);  //Used to Hold the Custom text Area
        }
        else if (index % 15 == 0)
        {
            // Start a new column.
            y = 50;
            x = 400;
        }
        ++index;
    
        // Previous code stays here, but must use x in new XRect(...)
    
        string colorStr = item.Color;
    
        Regex regex = new Regex(@"rgb\((?<r>\d{1,3}),(?<g>\d{1,3}),(?<b>\d{1,3})\)");
        //regex.Match(colorStr.Replace(" ", ""));
        Match match = regex.Match(colorStr.Replace(" ", ""));
        if (match.Success)
        {
            int r = int.Parse(match.Groups["r"].Value);
            int g = int.Parse(match.Groups["g"].Value);
            int b = int.Parse(match.Groups["b"].Value);
    
            y = y + 30;
            XRect ColorVal = new XRect(x + 85, y, 5, 5);
            XRect NameVal = new XRect(x + 100, y, 250, 25);
    
            var brush = new XSolidBrush(XColor.FromArgb(r, g, b));
            xGrap.DrawRectangle(brush, ColorVal);
            textformater.DrawString(item.Name, bodyfont, XBrushes.Black, NameVal);
    
        };
    };
