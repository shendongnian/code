    namespace SameAsPrincipal
    {
      public class Class1
      {
        private SQLiteConnection handle;
    
        public Class1(string db_file)
        {
          handle = new SQLiteConnection(db_file);
        }
    
        public int AddRecord(Record record)
        {
          // use handle to add record and get record Id
          return record.Id;
        }
        public void DeleteRecord(int id)
        {
          // Use handle to delete record
        }
      }
    }
