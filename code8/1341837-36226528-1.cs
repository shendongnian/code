    //In TransactionScope class
    
    public string Complete(var ids, int numFound, SqlConnection sqlConnection, string sqlTemplate1)
    {
    	string whereClause = $"WHERE Id IN ({string.Join(",", ids)})";
    
                                string sql1 = string.Format(sqlTemplate1, whereClause);
                                using (var sqlCommand1 = new SqlCommand(sql1, sqlConnection))
                                {
                                    sqlCommand1.ExecuteNonQuery();
                                }
    
                                var sql2 = "DELETE FROM SendGridEventRaw " + whereClause;
                                using (var sqlCommand2 = new SqlCommand(sql2, sqlConnection))
                                {
                                    sqlCommand2.ExecuteNonQuery();
                                }
                                return whereClause;
    }
    
    
    //in your Main class
    
    if (num > 0)
    {
    	string whereClause = scope.Complete(ids, numFound, sqlConnection, sqlTemplate1);
    	Console.WriteLine("deleted" + whereClause"." );
    }
