    // List<List<string>> termsList = the list to fill with nested lists
    //        List<string> sublist2 = a list created outside the loop
    //                    num_speed = number of columns to process
    for (i = 0; i < num_speed; i++)
    {
        var currentColumn = 12 + i * 11; // taken from if (currentWorksheet.Cells[j + 6, 12 + i * 11]
        var anotherColumn = 13 + i * 11; // taken from sublist2.Add(currentWorksheet.Cells[j + 6, 13 + i * 11]
        var lastRowOfCurrentColumn = GetLastUsedRow(currentWorksheet, currentColumn);
        for (int j = 0; j < lastRowOfCurrentColumn; j++)
        {
            var currentRow = j + 6; // taken from currentWorksheet.Cells[j + 6,
            var currentCell = currentWorksheet.Cells[currentRow, currentColumn];
            var anotherCell = currentWorksheet.Cells[currentRow, anotherColumn];
            // here you are checking if the cell has a value ...
            if (currentCell.Value != null)
    // was  if (currentWorksheet.Cells[j + 6, 12 + i * 11].Value != null)
            {
                if (j == 0)
                {
                    // ... but here ...
                    sublist2.Add(anotherCell.Value.ToString());
            // was  sublist2.Add(currentWorksheet.Cells[j + 6, 13 + i * 11].Value.ToString());
                }
                else
                {
                    // ... and here you are adding a 
                    // different cell value to the list
                    sublist2.Add(anotherCell.Value.ToString());
            // was  sublist2.Add(currentWorksheet.Cells[j + 6, 13 + i * 11].Value.ToString());
                }
            }
        }
        // Here you are adding the same list to the parent list
        // again and again for every row ...
        termsList.Add(sublist2);
    }
    // ... and outside the loop you are adding that list again to the parent
    termsList.Add(sublist2);
