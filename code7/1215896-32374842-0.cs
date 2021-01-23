     protected void Button1_Click(object sender, EventArgs e)
    {
        // ExportToPDFWithFormatting();
        Response.ContentType = "application/pdf";
        using (MemoryStream m = new MemoryStream())
        {
            try
            {
                // create the PDF document
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, m);
                // open document to add content
                document.Open();
                generatePDF(document);
                // close the document
                document.Close();
                // stream the PDF to the user
                Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Response.AddHeader("content-disposition", "inline;filename=AdHockTask.pdf");
        Response.End();
    }
    private void generatePDF(Document document)
    {
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Server.MapPath("~/close.png"));
        #region title
        PdfPTable title = new PdfPTable(3);
        title.TotalWidth = 550;
        title.LockedWidth = true;
        int[] headerwidths = { 20, 50, 30 }; // percentage
        title.SetWidths(headerwidths);
        title.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        title.DefaultCell.Border = 0;
        title.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
        title.AddCell(img);
        title.AddCell(new Phrase("Report", FontFactory.GetFont("Verdana", 12, Font.BOLD)));
        PdfPCell PintDate = new PdfPCell(new Phrase("Print Date: " + "  " + DateTime.Now.ToShortDateString(), FontFactory.GetFont("Verdana", 9, Font.NORMAL)));
        //PdfPCell RepID = new PdfPCell(new Phrase(currRepID, FontFactory.GetFont("Verdana", 10, Font.BOLD)));
        PintDate.HorizontalAlignment = Element.ALIGN_RIGHT;
        PintDate.VerticalAlignment = Element.ALIGN_MIDDLE;
        PintDate.Border = 0;
        title.AddCell(PintDate);
        document.Add(title);
        #endregion
        #region detail
        PdfPTable detail = new PdfPTable(5);
        detail.TotalWidth = 550f;
        detail.LockedWidth = true;
        float[] headerwidths1 = { 23, 12, 15, 15, 15 }; // percentage
        detail.SetWidths(headerwidths1);
        //detail.HeaderRows = 1;
        detail.SplitLate = false;
        //document.Add(new Paragraph(" "));
        PdfPCell eqipment = new PdfPCell();
        eqipment.HorizontalAlignment = Element.ALIGN_LEFT;
        eqipment.Colspan = 8;
        eqipment.PaddingBottom = 5f;
        PdfPTable EqipmentTable = GeneratePdfEquipmentPartsReplacement();
        eqipment.AddElement(EqipmentTable);
        detail.AddCell(eqipment);
        #endregion
        document.Add(detail);
    }
    private PdfPTable GeneratePdfEquipmentPartsReplacement()
    {
        PdfPTable tblEquipmentPartsReplacement = new PdfPTable(5);
        tblEquipmentPartsReplacement.TotalWidth = 550;
        tblEquipmentPartsReplacement.LockedWidth = true;
        int[] PartsUsedDuringRepairWidths = { 9, 13, 17, 9, 10 }; // percentage
        tblEquipmentPartsReplacement.SetWidths(PartsUsedDuringRepairWidths);
        tblEquipmentPartsReplacement.DefaultCell.Border = 1;
        tblEquipmentPartsReplacement.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        tblEquipmentPartsReplacement.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
        #region Header Section
        PdfPCell cellEquipmentPartsReplacement = new PdfPCell(new Phrase("Table Header", FontFactory.GetFont("Verdana", 10, Font.BOLD)));
        cellEquipmentPartsReplacement.Colspan = 9;
        cellEquipmentPartsReplacement.BackgroundColor = new Color(180, 180, 180);
        cellEquipmentPartsReplacement.PaddingBottom = 5f;
        tblEquipmentPartsReplacement.AddCell(cellEquipmentPartsReplacement);
        #endregion
        #region Grid's Headers
        PdfPCell cellPartIDAH = new PdfPCell(new Phrase("Column 1", FontFactory.GetFont("Verdana", 9, Font.BOLD)));
        cellPartIDAH.HorizontalAlignment = Element.ALIGN_CENTER;
        cellPartIDAH.BackgroundColor = new Color(235, 235, 235);
        PdfPCell cellEquipPartsAH = new PdfPCell(new Phrase("Column 2", FontFactory.GetFont("Verdana", 9, Font.BOLD)));
        cellEquipPartsAH.HorizontalAlignment = Element.ALIGN_LEFT;
        cellEquipPartsAH.BackgroundColor = new Color(235, 235, 235);
        PdfPCell cellPartNumberAH = new PdfPCell(new Phrase("HyperLink", FontFactory.GetFont("Verdana", 9, Font.BOLD)));
        cellPartNumberAH.HorizontalAlignment = Element.ALIGN_CENTER;
        cellPartNumberAH.BackgroundColor = new Color(235, 235, 235);
        PdfPCell cellSerialAH = new PdfPCell(new Phrase("Column 4", FontFactory.GetFont("Verdana", 9, Font.BOLD)));
        cellSerialAH.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSerialAH.BackgroundColor = new Color(235, 235, 235);
        PdfPCell cellDescriptionAH = new PdfPCell(new Phrase("HyperLink", FontFactory.GetFont("Verdana", 9, Font.BOLD)));
        cellDescriptionAH.HorizontalAlignment = Element.ALIGN_CENTER;
        cellDescriptionAH.BackgroundColor = new Color(235, 235, 235);
        /////////////////////////////////////////
        tblEquipmentPartsReplacement.AddCell(cellPartIDAH);
        tblEquipmentPartsReplacement.AddCell(cellEquipPartsAH);
        tblEquipmentPartsReplacement.AddCell(cellPartNumberAH);
        tblEquipmentPartsReplacement.AddCell(cellSerialAH);
        tblEquipmentPartsReplacement.AddCell(cellDescriptionAH);
        #endregion
        #region Grid's Values
        for (int i = 0; i < 10; i++)
        {
            //Equipment
            PdfPCell cellPartIDAV = new PdfPCell(new Phrase("partid- " + i, FontFactory.GetFont("Verdana", 8)));
            cellPartIDAV.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblEquipmentPartsReplacement.AddCell(cellPartIDAV);
            PdfPCell cellEquipPartsAV = new PdfPCell(new Phrase("test- " + i, FontFactory.GetFont("Verdana", 8)));
            cellEquipPartsAV.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblEquipmentPartsReplacement.AddCell(cellEquipPartsAV);
            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/close.png"));
            Chunk cImage1 = new Chunk(image1, 0, 0, false);
            Anchor anchor1 = new Anchor(cImage1);
            anchor1.Reference = "www.google.com";
            tblEquipmentPartsReplacement.AddCell(anchor1);
            PdfPCell cellSerialAV = new PdfPCell(new Phrase("test- " + i, FontFactory.GetFont("Verdana", 8)));
            cellSerialAV.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblEquipmentPartsReplacement.AddCell(cellSerialAV);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(Server.MapPath("~/close.png"));
            Chunk cImage = new Chunk(image, 0, 0, false);
            Anchor anchor = new Anchor(cImage);
            anchor.Reference = "www.yahoo.com";
            tblEquipmentPartsReplacement.AddCell(anchor);
        }
        return tblEquipmentPartsReplacement;
        #endregion
        //////////////////////////////////////////////
        //document.Add(tblEquipmentPartsReplacement);
    }
