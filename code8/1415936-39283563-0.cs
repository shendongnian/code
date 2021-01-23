        public class MyDbConnection : IDbConnection {
            private IDbConnection src;
            public MyDbConnection(IDbConnection src) {
                this.src = src;
            }
            public IDbCommand CreateCommand() {
                return new MyDbCommand(src.CreateCommand());
            }
            //TODO create pass-through implementations of the rest of IDbConnection methods...
        }
        public class MyDbCommand : IDbCommand {
            private IDbCommand src;
            public MyDbCommand(IDbCommand src) {
                this.src = src;
            }
            
            public int ExecuteNonQuery() {
                log.Info(src.CommandText);
                return src.ExecuteNonQuery();
            }
            public IDataReader ExecuteReader() {
                log.Info(src.CommandText);
                return src.ExecuteReader();
            }
            public IDataReader ExecuteReader(CommandBehavior behavior) {
                log.Info(src.CommandText);
                return src.ExecuteReader(behavior);
            }
            public object ExecuteScalar() {
                log.Info(src.CommandText);
                return src.ExecuteScalar();
            }
            //TODO create pass-through implementations of the rest of IDbCommand methods and properties...
        }
