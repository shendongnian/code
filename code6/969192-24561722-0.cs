    private class MyPrinter
    {
        private int i = 0;
    
        private void Print()
        {
            i = 0;
            printDocument1.Print();
        }
    
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             .....
             .....
             .....
    
             while (i < 100)
            {
                 graphic.DrawString("Line: " + i, font, brush, startX, startY + offsetY);
                 offsetY += (int)fontHeight;
    
                   if (offsetY >= pageHeight)
                    {
    
                        e.HasMorePages = true;
                        offsetY = 0;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;
    
                    }
                i = i + 1;
            }
        }
    }
