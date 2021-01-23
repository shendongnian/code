    private void Form11_Load(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Name FROM Patient where Patient_ID = @PatientID;", con);
        sda.SelectCommand.Parameters.Add("@PatientID", SqlDbType.Int).Value =  Convert.ToInt32(textBox1.Text);
        DataTable dt = new DataTable();
        sda.Fill(dt);
    
        // make sure to **CHECK** whether you actually **HAVE** a row!!
        if(dt.Rows.Count > 0)
        {
            // also: .Rows is **null-based** - the first entry is [0] ....
            textBox2.Text = dt.Rows[0]["Name"].ToString();
        }
     }
