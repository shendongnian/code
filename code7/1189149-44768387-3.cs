        private void GenerateExcelInvoiceController(ClosedXML.Excel.XLWorkbook workBook, string formtFileName)
        {
            
            string currentTime = DateTime.Now.ToString();
            string headerString = formtFileName.Replace("{0}", currentTime);
            headerString = headerString.Replace(" ", "");
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", headerString);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workBook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                memoryStream.Close();
            }
            Response.End();
        }
