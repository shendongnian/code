    virtual public Dictionary<string,PdfLayer> GetPdfLayers()
    {
        if (documentOCG.Count == 0)
        {
            ReadOCProperties();
        }
        ...
