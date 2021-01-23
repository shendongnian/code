        /// <summary>
        /// Creates an temporary excel-file for the report and returns it as byte-array
        /// </summary>
        /// <param name="reportResults"></param>
        /// <param name="reportDetails"></param>
        /// <returns></returns>
        private static byte[] GetReportExcelFile(Dictionary<string, DataSet> reportResults, ReportDetails reportDetails)
        {
            var tmpGuid = Guid.NewGuid();
            var tempFolderForExcelFile = $"{DefaultFolderForExcelFiles}{tmpGuid}";
            var exportFilePath = $"{tempFolderForExcelFile}\\{DefaultExcelFileName}";
            var templateFilePath = string.Empty;
            try
            {
                Cleanup.DeleteOldFiles(DefaultFolderForExcelFiles, 5, false, true);
                if (!Directory.Exists(tempFolderForExcelFile))
                {
                    Directory.CreateDirectory(tempFolderForExcelFile);
                }
                var excelExportManager = new ExcelExportManager();
                if (!string.IsNullOrEmpty(reportDetails.Template))
                {
                    // Create resultfile from template
                    exportFilePath = $"{tempFolderForExcelFile}\\OutputReport_{reportDetails.Template}";
                    templateFilePath = $"{tempFolderForExcelFile}\\Template_{reportDetails.Template}";
                    File.WriteAllBytes(templateFilePath, reportDetails.TemplateContent);
                }
                excelExportManager.AddDataSetToExcelFile(reportResults, exportFilePath, templateFilePath);
                using (var filstr = File.Open(exportFilePath, FileMode.Open))
                {
                    using (var ms = new MemoryStream())
                    {
                        ms.SetLength(filstr.Length);
                        filstr.Read(ms.GetBuffer(), 0, (int)filstr.Length);
                        ms.Flush();
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ReportingException(ex.Message);
            }
            finally
            {
                if (!string.IsNullOrEmpty(tempFolderForExcelFile))
                {
                    Directory.Delete(tempFolderForExcelFile, true);
                }
            }
        }
        public void AddDataSetToExcelFile(Dictionary<string, DataSet> resultSet, string exportFilePath, string templateFilePath = null)
        {
            var excelToExport = new FileInfo(exportFilePath);
            FileInfo template = null;
            if (!string.IsNullOrEmpty(templateFilePath))
            {
                template = new FileInfo(templateFilePath);
            }
            using (var excelPackage = string.IsNullOrEmpty(templateFilePath) ? new ExcelPackage(excelToExport) : new ExcelPackage(excelToExport, template))
            {
                foreach (var result in resultSet)
                {
                    var sheetCount = 1;
                    var sourceName = result.Key;
                    foreach (DataTable resultTable in result.Value.Tables)
                    {
                        var proposedSheetName = result.Value.Tables.Count == 1 ? sourceName : string.Format("{0}_{1}", sourceName, sheetCount);
                        var worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == proposedSheetName);
                        if (worksheet == null)
                        {
                            worksheet = excelPackage.Workbook.Worksheets.Add(proposedSheetName);
                            FillWorksheetWithDataTableContent(ref worksheet, resultTable, TableStyles.Medium27);
                        }
                        else
                        {
                            FillWorksheetWithDataTableContent(ref worksheet, resultTable);
                        }
                        sheetCount++;
                    }
                }
                excelPackage.SaveAs(excelToExport);
            }
        }
