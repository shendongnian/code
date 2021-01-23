    DataTable partyDsTable = partiesDb.Tables["party"]; //partiesDb is DataSet object
    
    if(partyDsTable == null) // instantiate it
        partyDsTable = new DataTable();
    for (int i = 0; i < size; i++)
    {
        ....
 
