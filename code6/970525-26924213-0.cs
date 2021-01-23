    namespace First_Csharp_app
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            String gender; //we have to define this
            private void button1_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(str);
                String str = "server=MUNESH-PC;database=windowapp;UID=sa;password=123";
                String query = "insert into data (E.id,name,surname,age,gender,DOB) values ('"+this.eid_txt.text+"','"+this.nametxt.text+"','"+this.surname_txt.text+"','"+this.age_txt.text+"' , '"+this.gender+"' , '"+this.DateTimePicker1.Text+"')";
                SqlCommand cmd = new sqComamnd(query,con);
                SqlDataReader dbr;
                try
                {
                    con.open();
                    dbr = cmd.ExecuteReader();
                    MessageBox.Show("saved");
                    while(dbr.read())
                    {
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            private void rediobutton1.checked(object sender, EventArgs e)
            {
                gender = "male";
            }
            private void rediobutton1.checked(object sender, EventArgs e)
            {
                gender = "female";
            }
        }
    }   
