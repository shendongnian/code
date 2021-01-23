    // Create Results DataTable
    DataTable ResultsDataTable = new DataTable();
    ResultsDataTable.Columns.Add("Account#"); // Columns default to System.string
    ResultsDataTable.Columns.Add("Occurances", Type.GetType("System.Int32"));
    ResultsDataTable.AcceptChanges(); //This asserts any changes to your table structure.
    // Populate Results DataTable
    foreach (DataRow SourceDataRow in SourceDataTable.Rows)
    {
        string AccountNumber = SourceDataRow["Account#"].ToString();
        bool IsPresent = false;
        foreach(DataRow ResultsDataRow in ResultsDataTable.Rows)
        {
            if(ResultsDataRow["Account#"].ToString() == AccountNumber)
            {
                ResultsDataRow["Occurances"] = ((int)ResultsDataRow["Occurances"]) + 1; //Row exists for this account number, so increment the occurances value
                IsPresent = true;
                break;
            }
        }
        if (!IsPresent)
        { 
            // There isn't a row for this Account number, so create one and set it to one.
            DataRow NewResultsRow = ResultsDataTable.NewRow();
            NewResultsRow["Account#"] = AccountNumber;
            NewResultsRow["Occurances"] = 1;
            ResultsDataTable.Rows.Add(NewResultsRow);
            ResultsDataTable.AcceptChanges();
                                        
        }
    }
    ResultsDataTable.AcceptChanges();
