    public partial class Form2 : Form
    {
    // for this we can reload after closing the form 2 the datagridview get refresh
            Form1 _owner;
            public Form2()
            {
                InitializeComponent();
            }
            public Form2(Form1 owner)
            {
                InitializeComponent();
                _owner = owner;
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            }
    
            String MyCon = "SERVER=*******;" +
                   "DATABASE=dtbas;" +
                   "UID=userid;" +
                   "PASSWORD=paswrd;" + "Convert Zero Datetime = True";
            public string a
            {
                get { return txtid.Text; }
                set { txtid.Text = value; }
            }
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
            {
                _owner.data();
            }
    
     private void Form2_Load(object sender, EventArgs e)
            {
    MySqlConnection con = new MySqlConnection(MyCon);
                con.Open();
                MySqlCommand Com = new MySqlCommand("Select * from student where id ='" + txtid.Text + "'", con);
                MySqlDataReader dt = Com.ExecuteReader();
                if (dt.Read())
                {
                // i assume (id textBox as txtid),(name textbox as txtname),(degree textbox as txtdegree),(college textbox as txtcollege),(city textbox as txtcity)
                    txtid.Text = dt.GetValue(0).ToString();
                    txtname.Text = dt.GetValue(1).ToString();
                    txtdegree.Text = dt.GetValue(2).ToString();
                    txtcollege.Text = dt.GetValue(3).ToString();
                    txtcity.Text = dt.GetValue(4).ToString();
               con.Close();
            }
    
    //button in form2 to save it in the database. (button as btnsave)
    
     private void btnsave_Click(object sender, EventArgs e)
     {
    
     MySqlConnection con = new MySqlConnection(MyCon);
                con.Open();
                string query = string.Format("Update student set id='" + txtid.Text + "' , name='" + txtname.Text + "' , degree='" + txtdegree.Text + "' , college='" + txtcollege.Text + "' , city='" + txtcity.Text + "'where id='" + txtid.Text + "'");
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
    
    }
    }
    }
