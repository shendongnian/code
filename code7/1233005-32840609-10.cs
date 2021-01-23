    cellText = (gvProducts.Rows[rowIndex].Cells[16].FindControl("hlKvm") as HyperLink).NavigateUrl;
    string imagePath = Server.MapPath((gvProducts.Rows[rowIndex].Cells[16].FindControl("hlKvm") as HyperLink).ImageUrl);
    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
    Chunk cImage = new Chunk(image, 0, 0, false);
    cImage.SetAction(new PdfAction(new Uri(cellText.ToString())));
    table.AddCell(new Phrase(cImage));
