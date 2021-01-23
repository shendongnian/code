    //event on which you want to show new form
    {
    if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["id"].Value.ToString();
                textBox3.Text = row.Cells["lastname"].Value.ToString();
                textBox4.Text = row.Cells["firstname"].Value.ToString(); 
				Form Form2=new Form(row);
				Form2.Show();
				//can use Form2.ShowDialog(); according to requirements
            }
     }
    //Constructor of form 2 
    public Form2(DataGridViewRow row)
    {
        InitializeComponent();
        tbx1.Text = row.Cells[0].Value.ToString();
        tbx2.Text = row.Cells[1].Value.ToString();
    }
