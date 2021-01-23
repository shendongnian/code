    public FileContentResult ExportToExcel(LedgerDetails obj)
    {
        //LedgerDetails obj = new Models.LedgerDetails();
        if (TempData["data"] != null)
        {
            List<LedgerData> liobj = new List<LedgerData>();
            liobj = (List<LedgerData>)TempData["data"];
        }
        if (TempData["datatable"] != null)
        {
            obj.LedgerTable = (DataTable)TempData["datatable"];
        }
        byte[] filecontent = Models.LedgerDetails.ExportExcel(obj.LedgerTable,obj);
        return File(filecontent, Models.LedgerDetails.ExcelContentType, "LedgerDetails.xlsx");
    }
