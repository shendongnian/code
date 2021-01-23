    Access.Application oAccess = null;
    
    // Start a new instance of Access for Automation:
    oAccess = new Access.ApplicationClass();
    
    // Open a database in exclusive mode:
    oAccess.OpenCurrentDatabase(
       "c:\\mydb.mdb", //filepath
       true //Exclusive
       );
    
    // Preview a report named Sales:
    oAccess.DoCmd.OpenReport(
       "Sales", //ReportName
       Access.AcView.acViewPreview, //View
       System.Reflection.Missing.Value, //FilterName
       System.Reflection.Missing.Value //WhereCondition
       );
