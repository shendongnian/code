    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        DoDetail_BeforePrint(e, false);
    }
    private void DoDetail_BeforePrint(System.Drawing.Printing.PrintEventArgs e, bool cancel)
    {
        if (cancel) e.Cancel = true;
        //other things
    }
    private void xrPictureBox8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        try
        {
            if (xrPictureBox8.ImageUrl.Length > 0) { }
            else
            {
                DoDetail_BeforePrint(e, true);
                //or just call e.Cancel = true here?
            }
        }
        catch (Exception)
        {
        }
    }
