     protected void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
    
            pdoc.PrintPage += pdoc_PrintPage;
    
            if (pd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pdoc.Print();
            }
        }
    
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(outerPanel.Width, outerPanel.Height);
            outerPanel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(5, 5, outerPanel.Width, outerPanel.Height));
            e.Graphics.DrawImage(bitmap, 5, 5);
            bitmap.Dispose();
        }
