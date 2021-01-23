    //Retrieve column schema into a DataTable.
    schemaTable = myReader.GetSchemaTable();
    
    //For each field in the table...
    foreach (DataRow myField in schemaTable.Rows){
        //For each property of the field...
        foreach (DataColumn myProperty in schemaTable.Columns) 
        {
    	CheckboxTyp1.Checked =	(bool) myField[myProperty]);
        }
