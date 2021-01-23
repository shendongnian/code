    private void Form1_Load(object sender, EventArgs e)
            {
                int j, i;
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                for ( j = 0; j < 10; j++)
                {
                    dt.Rows.Add("");
                }
                for ( i = 0; i < 10; i++)
                {
                    dt.Columns.Add("");
                }
                this.dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[0].Width = 100;
    
                
                for (int k = 0; k < dt.Rows.Count; k++ )
                {
                    Button edit = new Button();
                    edit.Text = "Edit";
                    Button delete = new Button();
                    delete.Text = "Delete";
                    this.dataGridView1.Controls.Add(edit);
                    this.dataGridView1.Controls.Add(delete);                      
                    //set its location and size to fit the cell
                    edit.Location = this.dataGridView1.GetCellDisplayRectangle(3, k, true).Location;
                    edit.Size = this.dataGridView1.GetCellDisplayRectangle(0, 1, true).Size;
                   
                    //set its location and size to fit the cell
                    delete.Location = this.dataGridView1.GetCellDisplayRectangle(4, k, true).Location;
                    delete.Size = this.dataGridView1.GetCellDisplayRectangle(0, 1, true).Size;
                }
            }
