        DataTable dt = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
           {    
             dt.Columns.Add ("Name");
             dt.Columns.Add ("Email");
             dt.Columns.Add ("ConatctNumber");        
            // dt.Rows.Add(dc1); dc1 is a column not a row   >>>
            // DataRow dr = dt.NewRow();  not necessary
             dataGridView1.DataSource = dt;
           }
         private void Submit_Click(object sender, EventArgs e)
            {
                DataRow dr = dt.NewRow();
                dr[0] = txtBox1.Text;
                dr[1] = txtBox2.Text;
                dr[2] = txtBox3.Text;
                 dt.rows.add(dr);   //You forgot to add new row in your datatable
                dataGridView1.DataSource = dt;
            }
