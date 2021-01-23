    /*Generar Vinculo (create hyperlink)**/
    public static Chunk GenerarVinculo(String tituloMostrar, string urlDirecion, iTextSharp.text.Font fuente)
    {
        Chunk espacioTab = new Chunk();
        try
        {
            if (String.IsNullOrEmpty(urlDirecion))
            urlDirecion = "Indice de Contenido";
    
            espacioTab = new Chunk(tituloMostrar, fuente);
            var accion = PdfAction.GotoLocalPage(urlDirecion, false);
            espacioTab.SetAction(accion);
        }                
        catch (Exception error) { }
        return espacioTab;
    }
