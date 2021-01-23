    public interface IDBConnection
    {
        IDBConnection CreateConnection();
        string ConType { get; set; }
    }
    
    public class BBAConnection : IDBConnection
    {
        public string ConType { get; set; }
    
        public IDBConnection CreateConnection()
        {
            string _connectionString = "";
            IDBConnection connection = null;
    
            if (ConType == "local")
            {
                _connectionString = "put here local db connection";
                connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            }
            else if (ConType == "remote")
            {
                _connectionString = "put here remote db connection";
                connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            }
            else if (ConType == "OrcsWeb")
            {
                _connectionString = "put here website db connection";
                connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            }
            else if (ConType == "Sage")
            {
                _connectionString = "put here sage connection";
                connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            }
    
            return connection;
        }
    }
    
    public static class Factory
    {
        static IUnityContainer cont = null;
    
        public static IDBConnection initialize(string type)
        {
            IDBConnection oDbConnection = null;
    
            cont = new UnityContainer();
            cont.RegisterType<IDBConnection, BBAConnection>("local");
            cont.RegisterType<IDBConnection, BBAConnection>("remote");
            cont.RegisterType<IDBConnection, BBAConnection>("OrcsWeb");
            cont.RegisterType<IDBConnection, BBAConnection>("Sage");
    
            oDbConnection = cont.Resolve<IDBConnection>(type);
            oDbConnection.ConType = type;
    
            return oDbConnection;
        }
    }
