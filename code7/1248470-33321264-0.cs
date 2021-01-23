    public abstract class Connection {
        protected Connection();
        public static Connection Create() {
            return new DefaultConnection();
        }
    }
    internal sealed class DefaultConnection : Connection {
        public DefaultConnection() {
            ...
        }
    }
