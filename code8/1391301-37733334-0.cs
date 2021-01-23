using System.Data.SQLite;
namespace sqlite_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("sample.db");
        }
    }
}
