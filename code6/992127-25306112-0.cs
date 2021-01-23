    int[] clmwidths111 = { 30, 20 };
        PdfPTable tbl14 = new PdfPTable(2);
        tbl14.SetWidths(clmwidths111);
        tbl14.WidthPercentage = 70;
        tbl14.HorizontalAlignment = Element.ALIGN_CENTER;
        tbl14.SpacingBefore = 25;
        tbl14.SpacingAfter = 10;
        tbl14.DefaultCell.Border = 1;
    foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                cell = new PdfPCell(new Phrase(((Literal)row.FindControl("Totalprem1")).Text, bodyFont2));
                cell.HorizontalAlignment = 0;
                cell.Colspan = 1;
                cell.Border = 0;
                tbl14.AddCell(cell);
                cell = new PdfPCell(new Phrase(((Literal)row.FindControl("Totalcom1")).Text, bodyFont2));
                cell.HorizontalAlignment = 2;
                cell.Colspan = 1;
                cell.Border = 0;
                tbl14.AddCell(cell);
            }
 
        }
