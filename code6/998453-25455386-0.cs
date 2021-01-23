    /// <summary>
    /// Create a Poco mapping class where the class name matches the Table name 
    /// and the properties match the column names and data types from the table
    /// </summary>
    public class Table{  
         public int ColumnName {get;set;} 
         public int ColumnName2 {get;set;}
    }
     int id = 1;
     var db = new Database("Connection Name");
     const string sql = @"SELECT 
                            1 columnName,
                            2 columnName2 
                          FROM Table 
                          WHERE ColumnName = @0";
     return db.FirstOrDefault<Table>(sql, id);
     or
     // Using auto-generated Select statement
     return db.FirstOrDefault<Table>("WHERE ColumnName = @0", id);
     // Fetch all records...
     return db.Fetch<Table>("");
     // PetaPoco also supports dynamic
     return db.FirstOrDefault<dynamic>(sql, id);
