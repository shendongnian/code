    private Exception HandleDbUpdateException(DbUpdateException dbu)
            {
                var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");
                if (!(dbu.InnerException is System.Data.Entity.Core.UpdateException) ||
                    !(dbu.InnerException.InnerException is System.Data.SqlClient.SqlException))
                {
                    try
                    {
                        foreach (var result in dbu.Entries)
                        {
                            builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                        }
                    }
                    catch (Exception e)
                    {
                        builder.Append("Error parsing DbUpdateException: " + e);
                    }
                }
                else
                {
                    var sqlException = (System.Data.SqlClient.SqlException)dbu.InnerException.InnerException;
                    for (int i = 0; i < sqlException.Errors.Count; i++)
                    {
                        builder.AppendLine("    SQL Message: " + sqlException.Errors[i].Message);
                        builder.AppendLine("    SQL procedure: " + sqlException.Errors[i].Procedure);
                    }
                }
    
                string message = builder.ToString();
                return new Exception(message, dbu);
            }
