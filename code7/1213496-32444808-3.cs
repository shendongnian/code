    private Cell createTextCell(int columnIndex, int rowIndex, object cellValue)
    {
        Cell cell = new Cell();
    
        cell.DataType = CellValues.InlineString;
        cell.CellReference = getColumnName(columnIndex) + rowIndex;
        InlineString inlineString = new InlineString();
        Text t = new Text();
    
        t.Text = cellValue.ToString();
        inlineString.AppendChild(t);
        cell.AppendChild(inlineString);
    
        return cell;
    }
