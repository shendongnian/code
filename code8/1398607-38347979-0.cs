      //Instantiate a new workbook
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                //Get the first worksheet in the workbook
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                //Import data from GridView control to fill the worksheet
                worksheet.Cells.ImportGridView(GridView1, 0, 0, new Aspose.Cells.ImportTableOptions() { IsFieldNameShown = true });
                worksheet.AutoFitColumns();
                //Send result to client in XLS format
                workbook.Save(this.Response, "export.xls", ContentDisposition.Attachment, new Aspose.Cells.XlsSaveOptions());
           
