    //setting up headers first
    int column = 1;
    foreach (var item in members)
    {
        xlWorksheet.Cells[1, column++].Value = item;
    }
    //setting up member values
    int row = 2;
    column = 1;
    foreach (var item in members)
    {
        xlWorksheet.Cells[row, column++].Value = item.Id;
        xlWorksheet.Cells[row, column++].Value = item.Login;
        xlWorksheet.Cells[row, column++].Value = item.AddDate;
        xlWorksheet.Cells[row, column++].Value = item.FirstName;
        xlWorksheet.Cells[row, column++].Value = item.LastName;
        xlWorksheet.Cells[row++, column].Value = item.FullName;
        column = 1;
    }
