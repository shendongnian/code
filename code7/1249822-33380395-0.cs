    private void Form1_Load(object sender, EventArgs e)
    {
            DataSet DSg = ACC_Data.Get_DT(File_Path.Text.ToString());
            var t = new DataTable(); 
            for (int c = 0; c < DSg.Tables[0].Columns.Count; c++) t.Columns.Add();
            
            for (int r = 0; r < DSg.Tables[0].Rows.Count; r++)
            {
                string[] Dr = new string[DSg.Tables[0].Columns.Count];
                int i = 0;
                foreach (DataColumn C in DSg.Tables[0].Columns)
                {
                   Dr[i] = DSg.Tables[0].Rows[r][C].ToString();
                   i++;
                }
                var row = t.Rows.Add(Dr);
            }
            dataGridView1.DataSource = t;
    }
