    DataSet ds = new DataSet("MyDataSetNameSpace");
    DataTable person = new DataTable();
    //add columns to the datatable
    person.Columns.Add(new DataColumn(typeof(string)), "FamilyName");
    person.Columns.Add(new DataColumn(typeof(string)), "GivenName");
