    try
    {
       // do your insert
    }
    catch(Exception ex)
    {
       if (ex.GetBaseException().GetType() == typeof(SqlException))
       {
           Int32 ErrorCode = ((SqlException)ex.InnerException).Number;
           switch(ErrorCode)
           {
              case 2627:  // Unique constraint error
                  break;
              case 547:   // Constraint check violation
                  break;
              case 2601:  // Duplicated key row error
                  break;
              default:
                  break;
            }
        }
        else
        {
           // handle normal exception
        }
    }
