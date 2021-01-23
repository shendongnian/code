    var printedLines = 0;
    var linesToPrint = 100;
    
    ...
    
    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        e.HasMorePages = false;
        ....
    
        
        while(printedLines < linesToPrint)
        {
             graphic.DrawString("Line: " + printedLines, font, brush, startX, startY + offsetY);
             offsetY += (int)fontHeight;
    
             ++printedLines;
             if (offsetY >= pageHeight)
             {
                  e.HasMorePages = true;
                  offsetY = 0;
                  return;
             }
        }
    }
