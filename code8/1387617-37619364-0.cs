    internal DataTable ParseNames(DataTable ConvertExcelToDataTable)
    {
        if (ConvertExcelToDataTable == null && ConvertExcelToDataTable.Rows == null)
        {
            return null;
        }
        var output = new DataTable();
        // Add columns here
        try
        {
          
           foreach(DataRow dr in ConvertExcelToDataTable.Select())
           {
               // Add rows here
           }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        return output;
    }
