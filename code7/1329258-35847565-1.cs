    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new Client();
            Debugger.Break();
            Debugger.Break();
        }
    }
    [DebuggerTypeProxy(typeof(ClientDebugView))]
    public class Client : MyBaseObject
    {
        private string _firstName;
        private string _lastName;
        public string FirstName
        {
            get
            {
                if (_firstName == null)
                    _firstName = LoadFromDatabase<string>("FirstName");
                return _firstName;
            }
            set
            {
                if (Equals(_firstName, value))
                    return;
                _firstName = value;
                UpdateDatabase(_firstName, "FirstName");
            }
        }
        public string LastName
        {
            get
            {
                if (_lastName == null)
                    _lastName = LoadFromDatabase<string>("LastName");
                return _lastName;
            }
            set
            {
                if (Equals(_lastName, value))
                    return;
                _lastName = value;
                UpdateDatabase(_lastName, "LastName");
            }
        }
        internal class ClientDebugView : MyBaseObjectDebugView
        {
            private readonly Client _client;
            public ClientDebugView(Client client)
                : base(client)
            {
                _client = client;
            }
            public string FirstName
            {
                get { return _client._firstName; }
            }
            public string LastName
            {
                get { return _client._lastName; }
            }
        }
    }
    [DebuggerTypeProxy(typeof(MyBaseObjectDebugView))]
    public class MyBaseObject
    {
        private Guid? _id;
        public Guid? Id
        {
            get
            {
                if (_id == null)
                    _id = LoadFromDatabase<Guid?>("Id");
                return _id;
            }
            set
            {
                if (Equals(_id, value))
                    return;
                _id = value;
                UpdateDatabase(_id, "Id");
            }
        }
        //Fake loading data from a database.
        protected T LoadFromDatabase<T>(string columnName)
        {
            object ret = null;
            switch (columnName)
            {
                case "Id":
                    ret = Guid.NewGuid();
                    break;
                case "LastName":
                    ret = "Smith";
                    break;
                case "FirstName":
                    ret = "John";
                    break;
                default:
                    ret = null;
                    break;
            }
            return (T)ret;
        }
        protected void UpdateDatabase<T>(T id, string s)
        {
            throw new NotImplementedException();
        }
        internal class MyBaseObjectDebugView
        {
            private readonly MyBaseObject _baseObject;
            public MyBaseObjectDebugView(MyBaseObject baseObject)
            {
                _baseObject = baseObject;
            }
            public Guid? Id
            {
                get { return _baseObject._id; }
            }
        }
    }
