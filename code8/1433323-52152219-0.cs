    List<PdfPCell> celdas = new List<PdfPCell>();
    string urlSection=String.empty;    
    var estatus = new Phrase();
    estatus.Leading = 25;
    if (streams != null && streams.Any())
        primero = streams.FirstOrDefault(x => x.Id == enlace.Id);
    if (primero != null)
        urlSection = primero.UrlSection;
    //For the code and generate hyperlink:
    Chunk espacioTab = new Chunk(" " + enlace.Name, baseFontBig );
    
    espacioTab = Visor.Servicios.GeneracionPDF.PDFUtils.GenerarVinculo(" " + enlace.Name, urlSection, baseFontBig);
    estatus.Add(espacioTab);
    if (incluirPaginado)
    {
       if (primero != null)
           actualPage = primero.TotalPages;
       else
           actualPage = 0;
    ///This is important, generate dots like "...." to chunk end 
        estatus.Add(new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator()));
        var linkPagina = new Chunk(actualPage.ToString());
        linkPagina = Visor.Servicios.GeneracionPDF.PDFUtils.GenerarVinculo(actualPage.ToString(), urlSection, baseFontBig );
        estatus.Add(linkPagina);
        resultado.paginaFinal = actualPage;
    }
    
    //This is for add to your cell or table
    PdfPCell rightCell = new PdfPCell()
    {
        Border = PdfPCell.NO_BORDER,
        Colspan = 3,
        PaddingLeft = espacioInicial.Length,
        ExtraParagraphSpace = 10,
    };
    rightCell.AddElement(estatus);
    celdas.Add(rightCell);
