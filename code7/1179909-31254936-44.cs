    //Find the "real" last used row.
    var rowRun = worksheet.Dimension.End.Row;
    while (rowRun >= 1)
    {
        var range = worksheet.Cells[rowRun, 1, rowRun, worksheet.Dimension.End.Column];
        if (range.Any(c => !string.IsNullOrEmpty(c.Text)))
        {
            break;
        }
        rowRun--;
    }
    // Loop through the worksheet and record the values we need.
    //var start = worksheet.Dimension.Start;
    for (int row = 2; row <= rowRun; row++)
    {
        //Check if we already have the current address
        string strHouseAddress = worksheet.Cells["A" + row.ToString()].Value == null ? string.Empty : worksheet.Cells["A" + row.ToString()].Value.ToString();
        rsAddress.Filter = "";
        rsAddress.Filter = "Address='" + strHouseAddress.Trim() + "'";
        if (rsAddress.RecordCount == 0)
        {
            //Record this address
            rsAddress.Filter = "";
            rsAddress.AddNew();
            rsAddress.Fields["Row"].Value = row;
            try
            {
                if (string.IsNullOrEmpty(strHouseAddress.Trim()) == false)
                {
                    rsAddress.Fields["Address"].Value = strHouseAddress.Trim();
                }
                else
                {
                    rsAddress.Fields["Address"].Value = "0 MISSING ST";
                    MessageBox.Show("Missing address at row " + row.ToString() + ".  Fix the spreadsheet and reload.");
                }
                string strTerminal = worksheet.Cells["E" + row.ToString()].Value == null ? string.Empty : worksheet.Cells["E" + row.ToString()].Value.ToString();
                if (string.IsNullOrEmpty(strTerminal.Trim()) == false)
                {
                    rsAddress.Fields["CustomerNumber"].Value = strTerminal.Trim();
                }
                rsAddress.Update();
            }
            catch
            {
                MessageBox.Show("Error reading data from column A on row " + row.ToString());
            }
        }
        else
        {
            MessageBox.Show("Duplicate address found on the Address list and row " + row.ToString() + ".");
        }
    }
