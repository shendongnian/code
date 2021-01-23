    DataTable dt ; // Patients information retrieved from db.
    
    foreach (DataColumn column in dt.Columns)
    {
    	column.ColumnMapping = MappingType.Attribute;
    }
    
    dt.WriteXml(@"C:\Patients.xml");  
