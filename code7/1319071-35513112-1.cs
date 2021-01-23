    public Form1 : Form
    {
        StringReader srPrint;
        public void PrintButton_Click(object sender, EventArgs e)
        {
            srPrint = new StringReader(this.rtb_results.Text);
            //DO all your normal stuff to start the print
        }
        void myPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringReader myStringReader = null;
            SolidBrush mySolidBrush = null;
            String line = String.Empty;
            Font myFont = null;
            float linesPerPage = 0;
            float leftMargin = 0;
            float topMargin = 0;
            float yPosition = 0;
            int count = 0;
            // assign the brush type
            mySolidBrush = new SolidBrush(Color.Black);
            // assign the font
            myFont = new Font("Consolas", 8.0F, FontStyle.Regular);
            // assign the left margin
            leftMargin = e.MarginBounds.Left;
            // assign the top margin
            topMargin = e.MarginBounds.Top;
            // assign the number of lines per page
            linesPerPage = e.MarginBounds.Height / myFont.GetHeight(e.Graphics);
            while (count < linesPerPage && ((line = srPrint.ReadLine()) != null))
            {
                yPosition = topMargin + (count * myFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, myFont, mySolidBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                srPrint.Close();
                srPrint.Dispose();
                srPrint = null;
            }
            mySolidBrush.Dispose();
        }
    }
