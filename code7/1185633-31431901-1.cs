    int colCount1 = gvProducts1.Columns.Count - 1;
    //Create a table
    PdfPTable table1 = new PdfPTable(colCount1);
    table1.HorizontalAlignment = 1;
    table1.WidthPercentage = 100;
    //create an array to store column widths
    int[] colWidths1 = new int[gvProducts1.Columns.Count];
    PdfPCell cell1;
    string cellText1;
    //create the header row
    for (int colIndex1 = 0; colIndex1 < colCount1; colIndex1++)
    {
        table1.SetWidths(new int[] { 0, 40, 120, 110, 60, 60, 100, 90, 100, 50, 50, 50, 40, 30, 260, 200, 0 });
        //fetch the header text
        cellText1 = Server.HtmlDecode(gvProducts1.HeaderRow.Cells[colIndex1].Text);
        //create a new cell with header text
        BaseFont bf1 = BaseFont.CreateFont(
                                BaseFont.HELVETICA,
                                BaseFont.CP1252,
                                BaseFont.EMBEDDED,
                                false);
        iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
        cell1 = new PdfPCell(new Phrase(cellText.Replace("<br />", Environment.NewLine), font));
        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
        cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
        cell1.FixedHeight = 45f;
        //set the background color for the header cell
        cell1.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#a52a2a"));
        //add the cell to the table. we dont need to create a row and add cells to the row
        //since we set the column count of the table to 4, it will automatically create row for
        //every 4 cells
        table1.AddCell(cell1);
    }
    //export rows from GridView to table
    for (int rowIndex1 = 0; rowIndex1 < gvProducts1.Rows.Count; rowIndex1++)
    {
        if (gvProducts.Rows[rowIndex1].RowType == DataControlRowType.DataRow)
        {
            for (int j1 = 0; j1 < gvProducts1.Columns.Count - 1; j1++)
            {
                //fetch the column value of the current row
                cellText1 = Server.HtmlDecode(gvProducts1.Rows[rowIndex1].Cells[j].Text);
                //create a new cell with column value
                cell1 = new PdfPCell(new Phrase(cellText1, FontFactory.GetFont("PrepareForExport", 8)));                   
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell1.FixedHeight = 25f;
                //Set Color of Alternating row
                if (rowIndex1 % 2 != 0)
                {
                    cell1.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#f5f5dc"));
                }
                else
                {
                    cell1.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#fcfcfc"));
                }
                //add the cell to the table
                table1.AddCell(cell1);
            }
        }
    }
    //Create the PDF Document
    //open the stream
    //add the table to the document
    pdfDoc.Add(table1);
    //close the document stream
    pdfDoc.Close();
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;" + DateTime.Now + ".pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.Write(pdfDoc);
    Response.End();
