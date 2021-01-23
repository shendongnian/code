    private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            for (int j = 0; j < 10; j++)
            {
                dt.Rows.Add("");
            }
            for (int j = 0; j < 10; j++)
            {
                dt.Columns.Add("");
            }
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].Width = 100;
    
            Button edit = new Button();
            edit.Text = "Edit";
            Button delete = new Button();
            delete.Text = "Delete";
            this.dataGridView1.Controls.Add(edit);
            //set its location and size to fit the cell
            edit.Location = this.dataGridView1.GetCellDisplayRectangle(0, 3, true).Location;
            edit.Size = this.dataGridView1.GetCellDisplayRectangle(0, 1, true).Size;
    
            this.dataGridView1.Controls.Add(delete);
            //set its location and size to fit the cell
            delete.Location = this.dataGridView1.GetCellDisplayRectangle(2, 3, true).Location;
            delete.Size = this.dataGridView1.GetCellDisplayRectangle(0, 1, true).Size;
        }
