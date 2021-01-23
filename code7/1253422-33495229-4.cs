    //Create a data table to store data when you load them in form load
    private DataTable dataTable;
    private void Form1_Load(object sender, EventArgs e)
    {
        dataTable = new DataTable();
        string constring = @"Data Source=Z46308;Initial Catalog=VSTest;Integrated Security=True";
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("select * from Personal_Details", con))
            {
                //Fill the data table here
                sda.Fill(dataTable);
            }
        }
        //Set the data source of grid
        this.DataGridView01.DataSource = new DataView(dataTable);
    }
    private void button3_Click(object sender, EventArgs e)
    {
        //Get the datasource from grid
        var dv = (DataView)this.DataGridView01.DataSource;
        //comboBox2.SelectedItem or comboBox2.SelectedValue based on your settings
        //Apply filter to data source
        dv.RowFilter = string.Format("{0} Like '%{1}%'",comboBox2.SelectedItem,   textBox1.Text);
    }
