    private DataTable dataTable = new DataTable();
    private void Form_Load(object sender, EventArgs e)
    {
        string constring = @"data source=(localdb)\v11.0;initial catalog=TestDB;integrated security=True;MultipleActiveResultSets=True;";
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT  * FROM Category", con))
            {
                sda.Fill(dataTable);
            }
        }
        this.listBox1.DataSource = new DataView(dataTable);
        this.listBox1.DisplayMember = "Name";
        this.listBox1.Visible = false;
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var dv = (DataView)this.listBox1.DataSource;
        dv.RowFilter = string.Format("Name Like '%{0}%'", this.textBox1.Text);
        listBox1.Visible = true;
    }
    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
        var item = (DataRowView)listBox1.SelectedItem;
        if (item != null)
            this.textBox1.Text = item["Name"].ToString();
        else
            this.textBox1.Text = "";
        this.listBox1.Visible = false;
    }
