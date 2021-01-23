    namespace ScratchPad
    {
        class Loading
        {
            public Loading()
            {
            public string _text1 = @"C:\Users\me\Documents\Defect DB\noemi.xlsx";
    
    
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _text1 + ";Extended Properties=\"Excel 12.0 XML;HDR=YES;IMEX=1\";"; 
    
            OleDbConnection con = new OleDbConnection(constr);
            var selectStatement = String.Format("Select * From [{0}$]", "excel");// _test2 is not working.
            OleDbDataAdapter adaptor = new OleDbDataAdapter(selectStatement, con);
    
            con.Open(); // if i leave _test1 like that then, this will fail.  private string _text1;
    
                DataTable table = new DataTable();
            adaptor.Fill(table);
            }
    
         } 
    }
