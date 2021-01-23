    [HttpGet]
    public async Task<PDFResult> ExportToPDF()
    {
        var model = new Models.MyDataModel();
        byte[] fileContents = await model.GetFileContents();
        string filename = "myfile.pdf";
        return new PDFResult(fileContents, filename);
    }
