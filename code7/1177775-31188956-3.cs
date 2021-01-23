    public ActionResult NumberOfRecordsChanged(int? numberOfRecords)
        {
            if (numberOfRecords.HasValue)
            {
                var model = new OperationLogViewModel
                {
                    Logs =
                        _serviceManager.GetOperationLogs(numberOfRecords.Value, 0,
                            new Guid("45726746-f62d-41cb-bdba-bc4c6ab6cc43"),
                            new Guid("ef8c3e19-179e-4303-afbb-21613c148b50")).ToList(),
                    NumberOfRecordsSelectList = new SelectList(new List<int> { 25, 50, 75, 100 }),
                    NumberOfRecords = numberOfRecords.Value
                };
    
                if (Request.IsAjaxRequest())
                {
                    return Json(new { ok = true, message = "", operationLogs = RenderPartialViewToString("_OperationLogs", model) }, JsonRequestBehavior.AllowGet);
                }
                else
                { 
                    return PartialView("_OperationLogs", model); 
                }
                return Content(RenderPartialViewToString("_OperationLogs", model));
            }
    
            return Json(new { ok = false, message = "Broken" }, JsonRequestBehavior.AllowGet);
        }
