    catch (SqlException ex)
    {
      Console.WriteLine(ex.Message);
      DisplaySqlErrors(ex);
    }
    
    private static void DisplaySqlErrors(SqlException exception)
    {
        for (int i = 0; i < exception.Errors.Count; i++)
        {
            Console.WriteLine("Index #" + i + "\n" +
            "Error: " + exception.Errors[i].ToString() + "\n");
        }
    }
