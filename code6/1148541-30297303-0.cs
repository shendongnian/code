        string[] newLineChars = { "\n", Environment.NewLine};
        string[] splittedVals = value.Split(newLineChars, StringSplitOptions.None);
        foreach (string val in splittedVals)
        {
            mWSheet1.Cells[excelRow, excelColumn] += val;   
        }
