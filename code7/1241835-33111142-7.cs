      /// <summary>
      /// Reads an Employee by its ID
      /// </summary>
      /// <param name="ID">Unique identifier</param>
      /// <param name="dbContext">Contains inforamtion about how to connect to database</param>
      /// <returns>Employee linked to ID; Null if no record is linked</returns>  
      public Employee ReadEmployee(string ID, IDataBaseContext dbContext)
      {
           if(string.IsNullOrWhiteSpace(ID))
               throw new ArgumentException("Unique id must be supplied to read the record");
           // Validate if the database can be accessed using db Context, if not throw another exception. 
           // Because it's preventing the API from doing its job
           // read and return the record
        }
