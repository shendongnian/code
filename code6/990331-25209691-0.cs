    private Tuple<string,int,string,int> SelectedCell(System.Windows.Controls.DataGrid dataGrid, int textIndex, int valueIndex)
        {            
            string cellText = null, cellValue = null;
            //if the text index is out of bounds, fix it
            if (dataGrid.SelectedCells.Count < textIndex)
            {
                textIndex = dataGrid.SelectedCells.Count - 1;
            }
            else if (textIndex < 0)
            {
                textIndex = 0;
            }
            //if the value index is out of bounds, fix it
            if (dataGrid.SelectedCells.Count < valueIndex)
            {
                valueIndex = dataGrid.SelectedCells.Count - 1;
            }
            else if (valueIndex < 0)
            {
                valueIndex = 0;
            }
            System.Data.DataRowView row = dataGrid.SelectedItem as System.Data.DataRowView;
            if(row != null)
            {
                cellText = row[textIndex].ToString();
                cellValue = row[valueIndex].ToString();
            }
            
            return new Tuple<string,int,string,int>(cellText,textIndex, cellValue, valueIndex);
        }
