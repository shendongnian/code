  using (var command = this.DbContext.Database.GetDbConnection().CreateCommand())
  {
      command.CommandText = "SELECT ... WHERE ...> @p1)";
      command.CommandType = CommandType.Text;
      var parameter = new SqlParameter("@p1",...);
      command.Parameters.Add(parameter);
     
      this.DbContext.Database.OpenConnection();
      using (var result = command.ExecuteReader())
      {
         while (result.Read())
         {
            .... // Map to your entity
         }
      }
  }
Try to SqlParameter to avoid Sql Injection.
 dbData.Product.FromSql("SQL SCRIPT");
FromSql doesn't work with full query.  Example if you want to include a WHERE clause it will be ignored.
Some Links:
[Executing Raw SQL Queries using Entity Framework Core][1]
[Raw SQL Queries][2]
  [1]: http://www.learnentityframeworkcore.com/raw-sql
  [2]: https://docs.microsoft.com/en-us/ef/core/querying/raw-sql
