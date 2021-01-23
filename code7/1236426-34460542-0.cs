    string path = @"c:\sample.xlsx";
    string strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + path + ";Extended Properties='Excel 12.0;'";
    OleDbConnection objConn = new OleDbConnection(strCon);
    
    string strCom = " SELECT * FROM [a$] ";
    objConn.Open();
