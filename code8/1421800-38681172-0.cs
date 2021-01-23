    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                CreateBackup("Server=localhost\\bekidev;Database=ApplifyAengine;Trusted_Connection=True;MultipleActiveResultSets=true",
                    "test", 
                    "C:\\temp\\test.bak");
            }
    
            private static void CreateBackup(string connectionString, string databaseName, string backupFilePath)
            {
                var backupCommand = "BACKUP DATABASE @databaseName TO DISK = @backupFilePath";
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(backupCommand, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@databaseName", databaseName);
                    cmd.Parameters.AddWithValue("@backupFilePath", backupFilePath);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
