    private void Form1_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.Add("001");
            bs.Add("002");
            bs.Add("003");
            bs.Add("004");
            bs.Add("005");
            try
            {
               DataGridViewComboBoxColumn combo1 = new DataGridViewComboBoxColumn();
                combo1.HeaderText = "DepartmentID";
                combo1.DataSource = bs;
                combo1.Width = 220;
                dataGridView1.Columns.Add(combo1);
                    DataGridViewTextBoxColumn text1 = new DataGridViewTextBoxColumn();
                    text1.Width = 200;
                    text1.HeaderText="DEPARTMENTNAME";
                    text1.ReadOnly = true;  
                    DataGridViewTextBoxCell txt = new DataGridViewTextBoxCell();
                    dataGridView1.Columns.Add(text1);
                    DataGridViewComboBoxColumn combo2 = new DataGridViewComboBoxColumn();
                    combo2.HeaderText = "Status";
                    combo2.Items.Add("Active");
                    combo2.Items.Add("InActive");
                    combo2.Width = 220;
                    dataGridView1.Columns.Add(combo2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("combo error");
            }
           
            
        }
