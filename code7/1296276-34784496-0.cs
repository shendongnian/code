      public class MyClass {
        //TODO: find a better names for Value1, Value2
        public String Value1 {get; private set}
        public String Value2 {get; private set}
    
        public static MyClass ReadFromDB() {    
          //TODO: Create a connection, SQL command here
           
          if (Reader.Read()) {
            return new MyClass() {
              // Do not forget about NULL
              Value1 = reader["val1"].IsDBNull ? null : Convert.ToString(reader["val1"]),
              Value2 = reader["val2"].IsDBNull ? null : Convert.ToString(reader["val2"])
            } 
          }
          else
            return null; // or throw an exception - no data in DB
        }
      }
    
    ...
    
      MyClass test = MyClass.ReadFromDb();
    
      Console.Write(test.Value1);
