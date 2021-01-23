    using OfficeOpenXml.Drawing;
    using OfficeOpenXml.Drawing.Chart;
    using OfficeOpenXml.Style;
    using OfficeOpenXml.Table;
    using OfficeOpenXml.Table.PivotTable;
    
    namespace OfficeOpenXml
    {
        public static class ExcelHelper
        {
           
            public static void Save(dynamic Table, string path)
            {
                var excel = CreateReport(Table);
                excel.SaveAs(path);
            }
            static void Save(this ExcelPackage excel, string path)
            {
                excel.SaveAs(path);
            }
            static ExcelWorksheet Export(ExcelPackage excel, dynamic Table, out ExcelRange range) // here it is your grid
            {
                var sheet = excel.Workbook.Worksheets.Add("Master_Data");
                int row=0, col=0;
                foreach (dynamic dc in Table.Columns)
                {
                    sheet.Cell(row, col++).Value = dc.Caption;
                }
                row++;
                col = 0;
    
                foreach (dynamic dr in Table.Rows)
                {
                    foreach (object value in dr.ItemArray)
                    {
                        sheet.Cell(row, col++).Value = value;
                    }
                    row++;
                    col = 0;
                }
                range= sheet.Cells[0, 0, row - 1,  Table.Columns.Count - 1];
                return sheet;
            }
    
            static ExcelPackage CreateReport(dynamic Table)
            {
                var excel = new ExcelPackage();
                ExcelRange range;
                ExcelWorksheet sheet;
                sheet = Export( excel, Table, out range);
    
                CreatePivotTable(range, TableStyles.Medium12);
                return excel;
            }
    
            static ExcelPivotTable CreatePivotTable(ExcelRange range, TableStyles tableStyle)
            {
                int count = range.Worksheet.Workbook.Worksheets.Count;
                var summary = range.Worksheet.Workbook.Worksheets.Add("PivotTable" + count);
                var pivotTable = summary.PivotTables.Add(summary.Cells["A3"], range, "Summary" + count);
    
                pivotTable.ApplyBorderFormats = true;
                pivotTable.ApplyNumberFormats = true;
    
                pivotTable.TableStyle = tableStyle;
                
                pivotTable.WorkSheet.View.ShowGridLines = false;
                pivotTable.MultipleFieldFilters = false;
                pivotTable.RowGrandTotals = false;
                pivotTable.ColumGrandTotals = false;
                pivotTable.Compact = false;
                pivotTable.CompactData = false;
                pivotTable.GridDropZones = false;
                pivotTable.Outline = false;
                pivotTable.OutlineData = false;
                pivotTable.ShowError = true;
                pivotTable.ErrorCaption = "[error]";
                pivotTable.ShowHeaders = false;
                pivotTable.UseAutoFormatting = true;
                pivotTable.ApplyWidthHeightFormats = true;
                pivotTable.ShowDrill = true;
                //pivotTable.DataOnRows = false;
                pivotTable.WorkSheet.View.FreezePanes(pivotTable.PageFields.Count + pivotTable.ColumnFields.Count + 3, 1);
    
    
                foreach (var fld in pivotTable.Fields)
                {
                    pivotTable.RowFields.Add(fld);
                    fld.Compact = false;
                    fld.Outline = false;
                    fld.ShowAll = false;
                    fld.SubtotalTop = false;
                    fld.SubTotalFunctions = eSubTotalFunctions.None;
                }
    
    
                return pivotTable;
            }
    
        }
    }
