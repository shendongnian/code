    public static bool ExcelExport(DataTable dt, string filename)
    {
        try
        {
            // using makes sure the streamwriter gets closed and disposed
            using (StreamWriter oExcelWriter = File.CreateText(filename))
            {
                // leadin
                oExcelWriter.Write(@"<HTML><BODY><TABLE Border=1>");
                //header
                oExcelWriter.Write("<TR>");
                foreach (DataColumn col in dt.Columns)
                {
                    oExcelWriter.Write(@"<TH>");
                    oExcelWriter.Write(col.ColumnName);
                    oExcelWriter.Write( @"</TH>");
                }
                oExcelWriter.Write("</TR>");
                // body 
                foreach (DataRow sonurow in dt.Rows)
                {
                    oExcelWriter.Write(@"<TR>");
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        oExcelWriter.Write(@"<TD>");
                        oExcelWriter.Write(sonurow[i]); // calls ToString in the overload
                        oExcelWriter.Write(@"</TD>");
                    }
                    oExcelWriter.Write(@"</TR>");
                }
                // leadout
                oExcelWriter.WriteLine(@"</TABLE></BODY></HTML>");
            }
        }
        catch(Exception exp)
        {
                Trace.WriteLine(exp.Message);
                return false;
        }
        return true;
    }
    
 
