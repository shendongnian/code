    String MyConnection = "SERVER=********;" +
                "DATABASE=dtabs;" +
                "UID=usrname;" +
                "PASSWORD=pswrd;" + "Convert Zero Datetime = True";
     public string id { get; private set; }
     private void Form1_Load(object sender, EventArgs e)
     {
             data();
            //Edit link
            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "Edit";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Edit";
            dataGridView1.Columns.Add(Editlink);
            //Delete link
            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            dataGridView1.Columns.Add(Deletelink);
    }
    //Make it as public for that only we call data() in form 2
     public void data()
    {
     MySqlConnection connection = new MySqlConnection(MyConnection);
            MySqlCommand command = new MySqlCommand("SELECT * from student;", connection);
            connection.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Refresh();
    }
      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         MySqlConnection conn = new MySqlConnection(MyConnection);
         conn.Open();
    //edit column 
       if (e.ColumnIndex == 5)
            {
                id =        Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells["id"].Value);
                Form2 frm2 = new Form3(this);
                fm2.a = id;
                fm2.Show();
                dataGridView1.Refresh();
    //delete column
            if (e.ColumnIndex == 6)
            {
            id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                    MySqlDataAdapter da = new MySqlDataAdapter("delete from student where id = '" + id + "'", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.Refresh();
            }
        }
