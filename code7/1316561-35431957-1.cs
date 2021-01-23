    try
    {
       _db.MyTable.Add(newRecord);
    }
    catch (SqlException ex)
    {
       if (ex.Number == 2627)
       {
         // Handle unique constraint violation.
       }
       else
       {
         // Handle the remaing SQL errors.
       }
    }
    catch (Exception e)
    {
      // Handle any other non-SQL exceptions
    }
