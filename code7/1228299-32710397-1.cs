        public void ExportToExcel()
        {
            using (var db = new EFDbContext())
            {
                var data = FetchDataAsList<MyDbEntityOrMvcModel>().ToDataTable();
                CreateExcelFile.CreateExcelDocument(data, "report.xlsx", System.Web.HttpContext.Current.Response);
            }
        }
