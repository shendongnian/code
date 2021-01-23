        private void myPrintDocument_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(myPicturebox.Width, myPicturebox.Height);
            myPicturebox.DrawToBitmap(myBitmap1, new Rectangle(0, 0, myPicturebox.Width, myPicturebox.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }
        private void btnPrintPicture_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            PrintDialog myPrinDialog1 = new PrintDialog();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
            myPrinDialog1.Document = myPrintDocument1;
 
            if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            {
               myPrintDocument1.Print();
            }
        }
 
