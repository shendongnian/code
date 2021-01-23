    Bitmap MemoryImage;
    PrintDocument printDoc = new PrintDocument();
    PrintDialog printDialog = new PrintDialog();
    PrintPreviewDialog printDialogPreview = new PrintPreviewDialog();
    Control panel = null;
    
    public void Print(Control pnl)
    {
        DateTime saveNow = DateTime.Now;
        string datePatt = @"yyyy-M-d_hh-mm-ss tt";
    
        panel = pnl;
        GetPrintArea(pnl);
        printDialog.AllowSomePages = true;
        printDoc.PrintPage += new PrintPageEventHandler(Print_Details);
        printDialog.Document = printDoc;
        printDialog.Document.DocumentName = "Document Name";
    
        //printDialog.ShowDialog();
        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            printDoc.Print();
        }
    }
    
    public void PrintPreview(Control pnl)
    {
        DateTime saveNow = DateTime.Now;
        string datePatt = @"yyyy-M-d_hh-mm-ss tt";
    
        panel = pnl;
        GetPrintArea(pnl);           
        printDoc.PrintPage += new PrintPageEventHandler(Print_Details);
        printDialogPreview.Document = printDoc;
        printDialogPreview.Document.DocumentName = "Document Name";
    
        //printDialog.ShowDialog();
        if (printDialogPreview.ShowDialog() == DialogResult.OK)
        {
            printDoc.Print();
        }
    }
    
    private void Print_Details(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        RectangleF marginBounds = e.MarginBounds;
    
        DateTime saveNow = DateTime.Now;
        string datePatt = @"M/d/yyyy hh:mm:ss tt";
        //String dtString = saveNow.ToString(datePatt);
    
        // create header and footer
        string header = "Put all information you need to display on the Header";
        string footer = "Print date : " + saveNow.ToString(datePatt);
    
        Font font = new Font("times new roman", 10, System.Drawing.FontStyle.Regular);
        Brush brush = new SolidBrush(Color.Black);
    
        // measure them
        SizeF headerSize = e.Graphics.MeasureString(header, font);
        SizeF footerSize = e.Graphics.MeasureString(footer, font);
        
        // draw header
        RectangleF headerBounds = new RectangleF(marginBounds.Left-80, marginBounds.Top-80, marginBounds.Width, headerSize.Height);
        e.Graphics.DrawString(header, font, brush, headerBounds);
    
        // draw footer
        RectangleF footerBounds = new RectangleF(marginBounds.Left-80, marginBounds.Bottom - footerSize.Height+80, marginBounds.Width, footerSize.Height);
        e.Graphics.DrawString(footer, font, brush, footerBounds);
    
        // dispose objects
        font.Dispose();
        brush.Dispose();
    }
    
    public void GetPrintArea(Control pnl)
    {
        MemoryImage = new Bitmap(pnl.Width, pnl.Height);
        Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
        pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        if (MemoryImage != null)
        {
            e.Graphics.DrawImage(MemoryImage, 0, 0);
            base.OnPaint(e);
        }
    }
    void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
        Rectangle pageArea = e.PageBounds;
        Rectangle m = e.MarginBounds;
    
        if ((double)MemoryImage.Width / (double)MemoryImage.Height > (double)m.Width / (double)m.Height) // image is wider
        {
            m.Height = (int)((double)MemoryImage.Height / (double)MemoryImage.Width * (double)m.Width);
        }
        else
        {
            m.Width = (int)((double)MemoryImage.Width / (double)MemoryImage.Height * (double)m.Height);
        }
    
        e.Graphics.DrawImage(MemoryImage, m);
    
    }
