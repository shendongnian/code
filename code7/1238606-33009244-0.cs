    //The connection string to the excel file
       string connstr = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=d:\temp\test.xls;Extended Properties=Excel 8.0";
       //The connection to that file
       OleDbConnection conn = new OleDbConnection(connstr);
       //The query
       string strSQL = "SELECT * FROM [Feuil1$]";
       //The command 
       OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
       DataTable dt = new DataTable();
       conn.Open();
       try
       {
         OleDbDataReader dr1 = cmd.ExecuteReader();
         StreamWriter sw = new StreamWriter("D:\\temp\\export.txt");
         if (dr1.Read())
         {
           dt.Load(dr1);
         }
         int iColCount = dt.Columns.Count;
         for (int i = 0; i < iColCount; i++)
         {
           sw.Write(dt.Columns[i]);
           if (i < iColCount - 1)
           {
             sw.Write("\t");
           }
         }
         sw.Write(sw.NewLine);
         // Now write all the rows.
         foreach (DataRow dr in dt.Rows)
         {
           for (int i = 0; i < iColCount; i++)
           {
             if (!Convert.IsDBNull(dr[i]))
             {
               sw.Write(dr[i].ToString());
             }
             if (i < iColCount - 1)
             {
               sw.Write("\t");
             }
           }
           sw.Write(sw.NewLine);
         }
         sw.Close();
         Console.WriteLine("File is saved");
       }
       catch (OleDbException caught)
       {
         Console.WriteLine(caught.Message);
       }
       finally
       {
         conn.Close();
       }
