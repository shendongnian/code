         public ActionResult UploadXls()
         {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if (file != null && !file.FileName.Contains(".xl"))
                {
                    TempData["description"] = "This file format is not supported, please use .xl or .xls formated file.";
                    //ModelState.AddModelError("File", "This file format is not supported");
                    return RedirectToAction("PropertyInventory", "PropertyBo", new { id = propertyId });
                }
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    var PropertyIn = new List<InventoryModelView>();
                    int idTemp = 0;
                    var alreadyExistInventoryList = new List<InventoryModelView>();
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            var inv = new PropertyInventory();
                            inv.PropertyId = propertyId;
                            if (string.IsNullOrEmpty(workSheet.Cells[rowIterator, 1].Value.ToString()))
                            {
                                continue;
                            }
                            else
                            {
                                inv.UnitNo = workSheet.Cells[rowIterator, 1].Value.ToString();
                            }
                           
                        }
                       
                    }                 
                }
            }
            TempData["description"] = "Great! Excel upload successfully";
            return RedirectToAction("abcd", "bcad", new { id = propertyId, flag = 1 });
        }
