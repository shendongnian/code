    OleDbDataAdapter custDA = new OleDbDataAdapter();
         DataSet custDS = new DataSet();
         DataTable custTable = new DataTable("Customers");
         custTable.Columns.Add("CustomerID", typeof(String));
         custTable.Columns.Add("CompanyName", typeof(String));
         custDS.Tables.Add(custTable);
         //Use ADO objects from ADO library (msado15.dll) imported
         //  as.NET library ADODB.dll using TlbImp.exe
         ADODB.Connection adoConn = new ADODB.Connection();
         ADODB.Recordset adoRS = new ADODB.Recordset();
         adoConn.Open("Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=Northwind;Integrated Security=SSPI;", "", "", -1);
         adoRS.Open("SELECT CustomerID, CompanyName FROM Customers", adoConn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, 1);
         custDA.Fill(custTable, adoRS);
         adoRS.Close();
         adoConn.Close();
