    namespace ScratchPad
    {
        class Loading
        {
         public string _text1;
         public string constr;
         public OleDbConnection con;
         public var selectStatement;
         public DataTable table;
            public Loading()
            {
            string _text1 = @"C:\Users\me\Documents\Defect DB\noemi.xlsx";
    
    
            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _text1 + ";Extended Properties=\"Excel 12.0 XML;HDR=YES;IMEX=1\";"; 
    
            con = new OleDbConnection(constr);
            selectStatement = String.Format("Select * From [{0}$]", "excel");// _test2 is not working.
            OleDbDataAdapter adaptor = new OleDbDataAdapter(selectStatement, con);
    
            con.Open(); // if i leave _test1 like that then, this will fail.  private string _text1;
    
             table = new DataTable();
            adaptor.Fill(table);
            }
    
         } 
    }
