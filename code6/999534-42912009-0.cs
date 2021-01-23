            //imagine a table with 5 columns
            DataTable dt = new DataTable();
            dt.TableName = "UniqueTableName";
            //define the cells where the headers will appear
            int topRow = 1;
            int leftMostColumn = 1;
            int rightMostColumn = 5;
            //bind the DataTable using LoadFromDataTable()
            OfficeOpenXml.ExcelRange excelRange = worksheet.Cells[topRow, leftMostColumn, topRow, rightMostColumn];
            excelRange.LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Light8);
            //turn of the filtering
            OfficeOpenXml.Table.ExcelTable table = worksheet.Tables[dt.TableName];
            table.ShowFilter = false;
