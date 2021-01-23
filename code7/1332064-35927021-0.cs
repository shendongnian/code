    using (pck = new ExcelPackage())
    {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");
                ws.Cells["A5:I5"].LoadFromDataTable(dt, true);
                ws.DefaultColWidth = 25;
                ws.Cells.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                ws.Cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                ws.Cells.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                ws.Cells.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                ws.Cells.Style.Border.Top.Color.SetColor(System.Drawing.Color.White);
                ws.Cells.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.White);
                ws.Cells.Style.Border.Left.Color.SetColor(System.Drawing.Color.White);
                ws.Cells.Style.Border.Right.Color.SetColor(System.Drawing.Color.White);
                var headerCell = ws.Cells["A5:I5"];
                headerCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headerCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.BurlyWood);
                var headerFont = headerCell.Style.Font;
                headerFont.Bold = true;
                int totalRow = ws.Dimension.End.Row;
                int totalCol = ws.Dimension.End.Column;
                using (ExcelRange rng = ws.Cells[6,1,totalRow,totalCol])
                {
                    rng.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                    rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                    rng.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                    rng.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                    rng.Style.Border.Top.Color.SetColor(System.Drawing.Color.White);
                    rng.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.White);
                    rng.Style.Border.Left.Color.SetColor(System.Drawing.Color.White);
                    rng.Style.Border.Right.Color.SetColor(System.Drawing.Color.White);
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Bisque);
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                ws.Cells["A4"].LoadFromText(name + " Generation Time: " + elapsedMs.ToString());
                Response.AddHeader("content-disposition", "inline;filename=" + name + ".xls");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.BinaryWrite(pck.GetAsByteArray());
    }
