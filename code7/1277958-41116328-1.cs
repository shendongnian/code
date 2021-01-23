    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;
    //Constructor
    public DBConnect()
    {
        Initialize();
    }
    //Initialize values
    private void Initialize()
    {
        server = "localhost";
        database = "connectcsharptomysql";
        uid = "username";
        password = "password";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
    }
    //open connection to database
    private bool OpenConnection()
    {
    }
    //Close connection
    private bool CloseConnection()
    {
    }
    //Insert statement
    public void Insert()
    {
    }
    //Update statement
    public void Update()
    {
    }
    //Delete statement
    public void Delete()
    {
    }
    //Select statement
    public List <string> [] Select()
    {
    }
    //Count statement
    public int Count()
    {
    }
    //Backup
    public void Backup()
    {
    }
    //Restore
    public void Restore()
    {
    }
