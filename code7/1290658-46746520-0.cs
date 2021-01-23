                                if (Model.LedgerTable.Rows.Count > 0)
                                {
    
    
    
                                    TempData["data"]= Model.LedgerTablelist(Model.LedgerTable);
                                    TempData["datatable"] = Model.LedgerTable; 
    
                                                <a href="@Url.Action("ExportToExcel", Model)" data-example-id="" class="btn btn-info" id="excelbtn" ><i class="fa fa-download" aria-hidden="true"></i>&nbsp;Download</a>
                        }
                        } <br/>
    
    Controller <b>
    public FileContentResult ExportToExcel(LedgerDetails obj)
            {
                //LedgerDetails obj = new Models.LedgerDetails();
                if (TempData["data"] != null) {
    
                    List<LedgerData> liobj = new List<LedgerData>();
                    liobj = (List<LedgerData>) TempData["data"];
                }
                if (TempData["datatable"] != null)
                {
                    obj.LedgerTable = (DataTable)TempData["datatable"];
    
                }
    
    
    
                byte[] filecontent = Models.LedgerDetails.ExportExcel(obj.LedgerTable,obj);
                return File(filecontent, Models.LedgerDetails.ExcelContentType, "LedgerDetails.xlsx");
            }
