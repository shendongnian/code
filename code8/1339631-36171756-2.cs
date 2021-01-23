    private void printDocument1_PrintPage(object sender,
                                          System.Drawing.Printing.PrintPageEventArgs e)
    {
       this.printDocument1.DefaultPageSettings.Landscape = true;
       if (!printImageOnPageTwo )
        using (Font fnt1 = new Font("Segoe UI", 12f, FontStyle.Regular))
        using (Font fnt2 = new Font("Arial", 13f, FontStyle.Bold))
        {
            e.Graphics.DrawString("just a text", fnt2,.....);
            ...
            ...
            if (dgvTheory.Height <= than 500)
                e.Graphics.DrawImage(...., y_InTheMiddle)
            else
            {
               printImageOnPageTwo = true:   // set our flag
               e.HasMorePages = true;        // set the system flag
               return;                       // quit the routine
            }
        }  // end if !printImageOnPageTwo 
        else  e.Graphics.DrawImage(...., y_AtTheTop);
        printImageOnPageTwo = false;         // reset our flag
    }
