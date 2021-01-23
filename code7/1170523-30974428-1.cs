    namespace Chat
    {
        internal class DBConnect
        {
            private MySqlConnection _connection = new MySqlConnection();
            private MySqlConnection _register = new MySqlConnection();
            private MySqlConnection _userdata = new MySqlConnection();
            private string _server;
            private string _database;
            private string _uid;
            private string _password;
            public String MessageRecieved;
            //private string _table = "testconnectie";
            private string _port;
            //private bool succes = false;
    
    
            //Constructor
            public DBConnect()
            {
                InitializeChat();
                InitializeRegister();
            }
    
            //Initialize values
            public void InitializeChat()
            {
                _server = "localhost";
                _port = "3307";
                _database = "test";
                _uid = "root";
                _password = "usbw";
    
                
                string connectionString = "Server=" + _server + ";" + "Port=" + _port +";" + "Database=" +
                                   _database + ";" + "Uid=" + _uid + ";" + "Pwd=" + _password + ";";
    
                _connection = new MySqlConnection(connectionString);
            }
    
            public void InitializeUserData()
            {
                _server = "localhost";
                _port = "3307";
                _uid = "root";
                _password = "usbw";
    
    
                string connectionString = "Server=" + _server + ";" + "Port=" + _port + ";" + "Database=" +
                                   _database + ";" + "Uid=" + _uid + ";" + "Pwd=" + _password + ";";
    
                _connection = new MySqlConnection(connectionString);
            }
    
            public void InitializeRegister()
            {
                _server = "localhost";
                _port = "3307";
                _database = "testlogin";
                _uid = "root";
                _password = "usbw";
    
    
                string registerString = "Server=" + _server + ";" + "Port=" + _port + ";" + "Database=" +
                                   _database + ";" + "Uid=" + _uid + ";" + "Pwd=" + _password + ";";
    
                _register = new MySqlConnection(registerString);
            }
    
            public bool OpenConnection()
            {
                try
                {
                    _register.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server");
                            break;
    
                        case 1042:
                            MessageBox.Show("Unable to connect to any of the specified MySQL hosts");
                            break;
    
                        case 1045:
                            MessageBox.Show("Invalid username/password");
                            break;
                    }
                    return false;
    
                }
                
            }
    
            public void Select()
            {
                string selectquery = "SELECT * FROM testconnectie";
                
                MySqlCommand cmd = new MySqlCommand(selectquery, _connection);
                
                MySqlDataReader dataReader = cmd.ExecuteReader();
    
                _messagelist.Clear();
                while (dataReader.Read())
                {
                    _messagelist.Add(dataReader["time"] + "      ");
                    _messagelist.Add(dataReader["text"] + "\r\n");
                }
    
                dataReader.Close();
    
    
                MessageRecieved = _messagelist.ToString(); 
    
            }
            
            public void Insert(string textvalue)
            {
                //DateTime dt = DateTime.Parse("6/22/2009 07:00:00 AM");
    
                //dt.ToString("H:mm"); // 7:00 // 24 hour clock
    
                //var now = DateTime.Now;
                //var minutes = now.Minute;
                //var hour = now.Hour;
                //var time = now;
    
                string time = DateTime.Now.ToString("HH:mm:ss");
    
                string insertquery = "INSERT INTO testconnectie(time, text) VALUES ('"+time+"','"+textvalue+"')";
    
                try
                {
                    MySqlCommand cmd = new MySqlCommand(insertquery, _connection);
    
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error(1)" + ex);
                }
            }
    
            private void Update()
            {
                string updatequery = "UPDATE tabelnaam SET waarde='', waarde'' WHERE waarde=''";
    
                MySqlCommand cmd = new MySqlCommand();
    
                cmd.CommandText = updatequery;
                cmd.Connection = _connection;
    
                cmd.ExecuteNonQuery();
            }
    
            private void Delete()
            {
                string deletequery = "DELETE FROM tabelnaam WHERE waarde=''";
    
                MySqlCommand cmd = new MySqlCommand(deletequery, _connection);
                cmd.ExecuteNonQuery();
            }
    
            public bool CloseConnection()
            {
                try
                {
                    _connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
    
                }
    
            }
    
    
            public void Backup()
            {
                try
                {
                    DateTime Time = DateTime.Now;
                    int year = Time.Year;
                    int month = Time.Month;
                    int day = Time.Day;
                    int hour = Time.Hour;
                    int minute = Time.Minute;
                    int second = Time.Second;
                    int millisecond = Time.Millisecond;
    
                    //Save file to C:\ with the current date as a filename
                    string path;
                    path = "C:\\ChatBackup" + year + "-" + month + "-" + day +
                "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                    StreamWriter file = new StreamWriter(path);
    
    
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "Database Backup";
                    psi.RedirectStandardInput = false;
                    psi.RedirectStandardOutput = true;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                _uid, _password, _server, _database);
                    psi.UseShellExecute = false;
    
                    Process process = Process.Start(psi);
    
                    string output;
                    output = process.StandardOutput.ReadToEnd();
                    file.WriteLine(output);
                    process.WaitForExit();
                    file.Close();
                    process.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error , unable to backup! " + ex);
                }
            }
    
    
    
        }
    
    }
