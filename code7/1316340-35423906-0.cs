    var rowCollection = GetData();
    for(int iRow = 0; iRow < RowCount; iRow++)
    {
        if(iRow["Col"] > 0)
        {
            rowCollection = GetData();
            RowCount=rowCollection.length();
            irow = 0;
        }
        else
        {
            //some processing statement
        }
    }
