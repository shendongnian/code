    p.PrintPage += PrintPage;
    ...
    private void PrintPage(object sender, PrintPageEventArgs e)
    {
        for (int i = 0; i < numberOfBarcodes; i++)
        {
            int titleY = i * titleYdistance + titleYoffset;
            // etc.
            e.Graphics.DrawString(...);
            // etc.
        }
    }
