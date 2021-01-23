    namespace WindowsFormsApplication8
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
            private MySqlConnection connection;
            private string server;
            private string database;
            private string uid;
            private string password;
    
            //Initialize values
            private void Initialize()
            {
                server = "net";
                database = "rainbow";
                uid = "ok";
                password = "passwd!";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
    
                connection = new MySqlConnection(connectionString);
            }
    
            //open connection to database
            private bool OpenConnection()
            {
    
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;
    
                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;
                        default :
                            MessageBox.Show("Connected Successfuly!!");
                            break;
                    }
                    return false;
                }
    
    
            }
    
            //Close connection
            private bool CloseConnection()
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
    
            //Insert statement
            public void Insert()
            {
                string query = "INSERT INTO mytable (username, password) VALUES('shryder', 'nopassword')";
    
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
    
                    //Execute command
                    cmd.ExecuteNonQuery();
    
                    //close connection
                    this.CloseConnection();
                }
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
            public List<string>[] Select()
            {
                string query = "SELECT * FROM mytable";
    
                //Create a list to store the result
                List<string>[] list = new List<string>[3];
                list[0] = new List<string>();
                list[1] = new List<string>();
                list[2] = new List<string>();
    
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
    
                    //Read the data and store them in the list
                    if (dataReader.Read())
                    {
                        /*list[0].Add(dataReader["username"] + "");
                        list[1].Add(dataReader["password"] + "");
                        list[2].Add(dataReader["email"] + "");*/
                        newscontent.Text = dataReader["username"]; //this is the error
    
    
                    }
    
                    //close Data Reader
                    dataReader.Close();
    
                    //close Connection
                    this.CloseConnection();
    
                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
    
            //Count statement
    
    
            //Backup
            public void Backup()
            {
            }
    
            //Restore
            public void Restore()
            {
            }
        }
    
    
    
    }
    }
