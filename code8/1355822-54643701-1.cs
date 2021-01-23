    private List<FundraiserStudentListModel> GetStudentsFromExcel(HttpPostedFileBase file)
        {
            List<FundraiserStudentListModel> list = new List<FundraiserStudentListModel>();
            if (file != null)
            {
                try
                {
                    using (ExcelPackage package = new ExcelPackage(file.InputStream))
                    {
                        ExcelWorkbook workbook = package.Workbook;
                        if (workbook != null)
                        {
                            ExcelWorksheet worksheet = workbook.Worksheets.FirstOrDefault();
                            if (worksheet != null)
                            {
                                list = worksheet.ImportExcelToList<FundraiserStudentListModel>();
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    //save error log
                }
            }
            return list;
        }
