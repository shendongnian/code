    <pre>
    public FileContentResult tofile(ZipLookupModel model)
    {
        model.SortBy = Session["SortBy"].ToString();
        model.ResultDestination = Session["ResultDestination"].ToString();
        model.ZipCode = Session["ZipCode"].ToString();
        model.WebResponse = WebService.ZipLookup(model.ZipCode, model.SortBy);
        if (model.ResultDestination.Contains("CSVFile"))
        {
            return new FileContentResult(writeHamsToCSV(model).ToArray(), "text/csv");
        }
        else
        {
            return new FileContentResult(writeHamsToExcel(model).ToArray(), "application/vnd.ms-excel");
        }
    }
    </pre>
