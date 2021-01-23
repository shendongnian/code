                               int? totalClientURL = 0;   
                               int? totalHgURL = 0;
                                    foreach (var d in results5)
                                    {
                                        int col = 6;
                                        worksheet.Cells[row, col++].Value = d.employees_range;
                                        worksheet.Cells[row, col].StyleName = styleData;
                                        worksheet.Cells[row, col++].Value = d.client_url_count;
                                        totalClientURL += d.client_url_count;
                                        worksheet.Cells[row, col].StyleName = styleData;
                                        worksheet.Cells[row, col++].Value = d.url_count;
                                        totalHgURL += d.url_count;
                                        row++;
                                        ExportCount++;
                                        if (ExportCount % 100 == 0)
                                            Worker.ReportProgress(20, ExportCount + " rows exported of " + TotalRows);
                                    }
                                    int TotalCol = 6;
                                    worksheet.Cells[row, TotalCol++].Value = "Total";
                                    worksheet.Cells[row, TotalCol].StyleName = styleData;
                                    worksheet.Cells[row, TotalCol++].Value = totalClientURL;
                                    worksheet.Cells[row, TotalCol].StyleName = styleData;
                                    worksheet.Cells[row, TotalCol++].Value = totalHgURL;                                 
