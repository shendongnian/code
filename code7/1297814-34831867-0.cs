    public class DBTools
    {
        public string table_name = "NULL";
        public void Delete(string table_name, int id)
        {
            Console.WriteLine(table_name);
            // whatever work is required for the given table name
        }
    }
    public class User : DBTools
    {
        public string table_name = "users";
        public void Delete(int id)
        {
            Delete(table_name, id);
        }
    }
