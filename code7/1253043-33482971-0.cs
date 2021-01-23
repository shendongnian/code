    DataTable newTable = new DataTable();
    newTable.TableName = "<NewTableName>";
    //Make a new Random generator
    Random rnd = new Random();
    while (<new table length> != <old table length>)
    {
        //We'll use this to make sure we don't have a duplicate row
        bool rowFound = false;
        //index generation
        int index = rnd.Next(0, <max number of rows in old data>);
        //use the index on the old table to get the random data, then put it into the new table.
        foreach (DataRow row in newTable.Rows)
        {
            if (oldTable.Rows[index] == row)
            {
                //Oops, there's duplicate data already in the new table. We don't want this.
                rowFound = true;
                break;
            }
        }
        if (!rowFound)
        {
            //add the row to newTable
            newTable.Rows.Add(oldTable.Rows[index];
        }
    }
