    private DataTable dataTable = new DataTable();
    private void Form1_Load(object sender, EventArgs e)
    {
        string constring = @"Data Source=.;Initial Catalog=Test;User Id=sa;Password=admin@123";
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT  * FROM CategorySELECT distinct * FROM Item_Details", con))
            {
                sda.Fill(dataTable);
            }
        }
        this.listBox1.DataSource = new DataView(dataTable);
        this.listBox1.DisplayMember = "IName";
        this.listBox1.Visible = false;
    }
    private void txtIName_TextChanged(object sender, EventArgs e)
    {
        var dv = (DataView)this.listBox1.DataSource;
        dv.RowFilter = string.Format("IName Like '%{0}%'", txtIName.Text);
        listBox1.Visible = true;
    }
    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
        var item = (DataRowView)listBox1.SelectedItem;
        if (item != null)
            this.txtIName.Text = item["Name"].ToString();
        else
            this.txtIName.Text = "";
        this.listBox1.Visible = false;
    }
