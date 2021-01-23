    /* loop that take values from every row in datatable and insert in itextsharp table */
            for (int k = 0; k < intRows; k++)
            {
                for (int j = 2; j < intCols; j++)// EDIT: if all first 3 cols are same, then starts with 2
                { 
                    iTextSharp.text.Cell cellRows = new iTextSharp.text.Cell();
                    if(j == 2) cellRows.Colspan = 3;// ADD: it'll gives a 3 times long cell
                    iTextSharp.text.Font RowFont = iTextSharp.text.FontFactory.GetFont("Tahoma", 07);
                    iTextSharp.text.Chunk chunkRows = new iTextSharp.text.Chunk(dtChartData.Rows[k][j].ToString(),RowFont);
                    cellRows.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cellRows.Add(chunkRows);
                    pdfTable.AddCell(cellRows);
                }
            }
