    private DataTable dataTable = new DataTable();
    private void Form1_Load(object sender, EventArgs e)
    {
        string constring = @"Data Source=Z46308;Initial Catalog=VSTest;Integrated Security=True";
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("select * from Personal_Details", con))
            {
                sda.Fill(dataTable);
            }
        }
        this.DataGridView01.DataSource = new DataView(dataTable);
    }
    private void button3_Click(object sender, EventArgs e)
    {
        var dv = (DataView)this.DataGridView01.DataSource;
        dv.RowFilter = string.Format("{0} Like '%{1}%'",comboBox2.SelectedItem,   textBox1.Text);
    }
