    int page = 0; 
    void Imprimir()
    {
        // snip irrelevant stuf
        if (result == DialogResult.OK)
        {   
            // reset our state to page 1
            page = 1;
            pd.Print();
        }
    }
    private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        // this gets called twice, the page variable
        // keeps track of what to do (it keeps the State)
        switch(page)
        {
            // do this for page 1
            case 1:
                Bitmap bmp = new Bitmap(pnlPrint.Width, pnlPrint.Height, pnlPrint.CreateGraphics());
                pnlPrint.DrawToBitmap(bmp, new Rectangle(0, 0, pnlPrint.Width, pnlPrint.Height));
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)bmp.Height / (float)bmp.Width);
                e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, 1118, 855);
                e.HasMorePages = true;
                break;
            // do this for page 2
            case 2:
                Bitmap bmp1 = new Bitmap(dgvDetGraf.Width, dgvDetGraf.Height, dgvDetGraf.CreateGraphics());
                dgvDetGraf.DrawToBitmap(bmp1, new Rectangle(0, 1800, dgvDetGraf.Width, dgvDetGraf.Height));
                RectangleF bounds1 = e.PageSettings.PrintableArea;
                e.Graphics.DrawImage(bmp1, bounds1.Left, bounds1.Top, 894, 684);
                e.HasMorePages = false;
                break;
        }
        // don't forget to go the next state ... 
        page++; // increase page counter
    }
