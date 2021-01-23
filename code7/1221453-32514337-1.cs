    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        int linesCount = 0;
        float yPosition = 10;
        // take the next item from the list by calling MoveNext
        // and assign the outcome to e.HasMorePages
        while(e.HasMorePages = this.ObjectsEnumerator.MoveNext())
        {
            var tuple = this.ObjectsEnumerator.Current;
            switch (tuple.Item2)
            {
                case LineTypes.LINE:
                    // draw magic
                    e.Graphics.DrawString(tuple.Item1.ToString(), font, solidBrush, new PointF(10,yPosition));
                    yPosition += 300;
                    linesCount++;
                    break;
                case LineTypes.IMAGE:
                    Image Image = (Image)tuple.Item1;
                    // e.Graphics.DrawImage(....);
                    // calculate new yPosition
                    yPosition += Image.Height;
                    break;
            }
            // if we reach the end of the page
            if (yPosition >= e.PageSettings.PrintableArea.Height)
            {
                //we break out of the while loop
                // e.HasMorePages is already set
                break;
            }
        }
    }
