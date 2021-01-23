    public static void Write(
            _Worksheet worksheet, object[,] values, int rowIndex, int columnIndex, ExcelFormatter formatter)
        {
            if (worksheet == null)
            {
                return;
            }
            if (values == null)
            {
                return;
            }
            var range = (Range)worksheet.Cells.Item[1, 1];
            // range = range.get_Offset(rowIndex, columnIndex);  // this did not work when cell 1,1 is a merged cell (column wise); offset moves by columns first before rows
            range = range.Offset[rowIndex, 0]; // this partially solves the problem 
            range = range.Offset[0, columnIndex];
                
            // may need a different algo if cell 1,1 is a merged cell (row wise)
            range = range.Resize[values.GetLength(0), values.GetLength(1)];
            range.set_Value(XlRangeValueDataType.xlRangeValueDefault, values);
            if (formatter != null)
            {
                formatter.Invoke(range);
            }
            ReleaseObject(range);
        }
