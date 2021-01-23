    [HttpGet]
    public FileStreamResult DownloadFile()
    {
        var Document = _repository.GetDocumentByGuid(vm.DocumentGuid, User.Identity.Name);
        var Params = Helper.ClientInputToRealValues(vm.Parameters, Document.DataFields);
        var file = Helper.GeneratePdf(Helper.InsertValues(Params, Document.Content));
        var stream = new FileStream(file,FileMode.Open);
        return new FileStreamResult(stream, "application/pdf")
        {
            FileDownloadName = "test.pdf"
        };
    }
