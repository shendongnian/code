            using (var stream = new MemoryStream())
                {
                    // ok, we can run the real code of the sample now
                    using (var xlPackage = new ExcelPackage(stream))
                    {
                        // get handles to the worksheets
                        var worksheet = xlPackage.Workbook.Worksheets.Add("SheetName");
                        worksheet.Cells["A1"].LoadFromCollection(itemsToExport, true, TableStyles.Medium15);
                        xlPackage.Save();
                    }
