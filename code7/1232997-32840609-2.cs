    cellText = (gvProducts.Rows[rowIndex].Cells[16].FindControl("hlKvm") as HyperLink).NavigateUrl;
    string imagePath = Server.MapPath((gvProducts.Rows[rowIndex].Cells[16].FindControl("hlKvm") as HyperLink).ImageUrl);
    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
    Annotation annotation = new Annotation(0, 0, 0, 0, cellText);
    image.Annotation = annotation;
    table.AddCell(image);
