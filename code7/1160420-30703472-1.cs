    public interface IMyQuery {
        string GetCommand();
    }
    public class MyInsert : IMyQuery{
        public string GetCommand() {
            return "INSERT ...";
        }
    }
    class DBNonQueryRunner {
        public void RunQuery(IMyQuery query) {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString)) {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction()) {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandTimeout = 900;   // Wait 15 minutes before a timeout
                    command.CommandText = query.GetCommand();
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }
    }
