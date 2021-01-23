        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT TOP 1,[Sender Name],[Subject] "
                            + " from[OLE DB Destination] WHERE[CHAT #] = :chatId ";
            using (SqlConnection con = new SqlConnection("Data Source=USHOU2016\\USFi;Initial Catalog=HOU_2016_Project;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("chatId", textBox1.Text); //use Sql parameters to protect yourself against Sql Injection!
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    textBox2.Text = reader[0] + " " + reader[1]; //or however you want your output formatted 
                }
                 reader.close();
            }
        }
        }
