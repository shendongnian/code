        private PrintDocument document =   new PrintDocument();
        private void printButton_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = document;
            ppd.Document.DocumentName = "TESTING";
            document.PrintPage += document_PrintPage;
            ppd.ShowDialog();
        }
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            int leading = 5;
            int leftMargin = 25;
            int topMargin = 10;
            StringFormat FmtRight = new StringFormat() { Alignment = StringAlignment.Far};
            StringFormat FmtLeft = new StringFormat() { Alignment = StringAlignment.Near};
            StringFormat FmtCenter = new StringFormat() { Alignment = StringAlignment.Near};
            StringFormat fmt = FmtRight;
            using (Font font = new Font( "Arial Narrow", 12f))
            {
            SizeF sz = e.Graphics.MeasureString("_|", Font);
            float h = sz.Height + leading;
            for (int i = 0; i < listBox1.Items.Count; i++)
                e.Graphics.DrawString(listBox1.Items[i].ToString(), font , Brushes.Black, 
                                      leftMargin, topMargin + h * i, fmt);
            }
        }
