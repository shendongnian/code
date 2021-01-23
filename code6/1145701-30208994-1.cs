    public test()
    {
        InitializeComponent();
        using(SqlConnection cn = new SqlConnection("Server=AMEER;DataBase=custemer_net;Integrated security=true"))
        {
            var adapter = new SqlDataAdapter("Select *from subscrbtion ", cn);
            adapter.Fill(dt);
        }
        comboBox1.DisplayMember = "name";
        comboBox1.ValueMember = "id";
        comboBox1.DataSource = dt;
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //for testing
        MessageBox.Show(comboBox1.SelectedValue.ToString());
        //
        //clear the datatable dttt
        dttt.Clear();                  //<----------THIS SHOULD BE YOUR NEW SOLUTION
        //refill the datatable with the new information
        using(SqlConnection cn = new SqlConnection("Server=AMEER;DataBase=custemer_net;Integrated security=true"))
        {
            var adapter = new SqlDataAdapter("select * from subscrbtion where id='" + comboBox1.SelectedValue + "'", cn);
            adapter.Fill(dttt);
        }
        //for testing
        MessageBox.Show(dttt.Rows.Count.ToString());
        //
        //show the data inside the textbox.
        textBox1.Text = dttt.Rows[0]["phone"].ToString();
    }
