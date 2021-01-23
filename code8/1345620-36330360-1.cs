    using (var importConnection = new OleDbConnection(....))
    using (OleDbCommand CodeChange = new OleDbCommand(
       @"select NUM from SYSTEMNUMBERS; 
        select PROPCODE from PROPERTY order by PROPCODE", importConnection))
    {
        importConnection.Open();
        DataTable sysNum = new DataTable();
        DataTable props = new DataData();
        Console.WriteLine("Visual Foxpro connection open");
        var exportReader = CodeChange.ExecuteReader();
        sysNum.Load(exportReader);
        exportReader.NextResult();
        props.Load(exportReader);
        for (int x = 0; x < sysNum.Rows.Count; x++)
        {
            // Set parameter values whilst reading from SQL
            Int32 currentNum = Int32.Parse(sysNum.Rows[i][0]);
            string propcode = props.Rows[i][0].ToString();
            
            .... continue with your current code ....
            .... but remove this part.....
    //            try
    //            {
    //                CodeChange.ExecuteNonQuery();
    //            }
    //            catch (Exception e)
    //            {
    //                Console.Write("Error Writing to database");
    //                Console.Write(e);
    //                Console.ReadKey();
    //            }
        }
    }
    // done
    Console.WriteLine("Complete!");
