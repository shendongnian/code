     CsvUtility csv = new CsvUtility();
            var dt = csv.Csv2DataTable("f1.txt");
          
            // Search for  string in any column  
            DataRow[] filteredRows = dt.Select("Field1 LIKE '%" + "Thomas" + "%'"); 
            //search in certain field
            var filtered = dt.AsEnumerable().Where(r => r.Field<string>("Field1").Contains("Thomas"));
            
            //generate xml
            var xml=  csv.Csv2Xml("f1.txt");
            Console.WriteLine(xml);
    /*
        output of xml for your sample:
       <DocumentElement>
         <Table>
           <Field0>Book 31</Field0>
           <Field1> Thomas</Field1>
           <Field2>George</Field2>
           <Field3> 32</Field3>
           <Field4> 34</Field4>
           <Field5> 154</Field5>
        </Table>
    </DocumentElement>
     */
   
