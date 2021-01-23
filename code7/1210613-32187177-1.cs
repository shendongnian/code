    public partial class Form1 : Form
    {
    private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(0,20);
        }
    public void LoadData(int x, int y)
        {
            server = "localhost";
            database = "app";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            if (this.OpenConnection() == true)
            {
                string query = "SELECT * from EVENTS LIMIT"+ x +","+ y +";";
                mySqlDataAdapter = new MySqlDataAdapter(query , connection);
                ...
                ...
            }
        }
    private void button1_Click(object sender, EventArgs e)
        {
            LoadData(0,20);
        }
    private void button2_Click(object sender, EventArgs e)
        {
            LoadData(20,40);
        }
     }
