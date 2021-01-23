    private void button1_Click(object sender, EventArgs e)
    {
        imgs.Add(img1);
        imgs.Add(img2);
        imgs.Add(img3);
        imgs.Add(img4);
        try
        {
            PrintDocument pd = new PrintDocument();
                
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.Print();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
        
    private void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        Graphics graphic = e.Graphics;
        Point p = new Point(10, 10);
        Image img = Image.FromFile(imgs.ElementAt(page));
        graphic.DrawImage(img, p);
        page++;
        e.HasMorePages = page < imgs.Count;
        img.Dispose();
    }
