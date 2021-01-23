     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                cboDepartment.Visible = false;
                InitGrid();
            }
    
            private void InitGrid()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Department", typeof(string));
    
                DataRow dr = dt.NewRow();
                dr["Name"] = "";
                dr["Department"] = "";
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["Name"] = "";
                dr["Department"] = "";
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["Name"] = "";
                dr["Department"] = "";
                dt.Rows.Add(dr);
    
    
                dr = dt.NewRow();
                dr["Name"] = "";
                dr["Department"] = "";
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["Name"] = "";
                dr["Department"] = "";
                dt.Rows.Add(dr);
    
                dataGridView1.DataSource = dt;
                cboDepartment.SelectedIndex = 0;
    
            }
    
            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 1)
                {
                    this.cboDepartment.Location = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                    this.cboDepartment.Size = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Size;
                    this.dataGridView1.Controls.Add(cboDepartment);
                    cboDepartment.Select();
                    cboDepartment.Focus();
                    cboDepartment.SelectedIndexChanged += new EventHandler(cboDepartment_SelectedIndexChanged);
                    if (this.dataGridView1.CurrentCell.Value.ToString() == "")
                        cboDepartment.SelectedIndex = 0;
                    else
                        this.cboDepartment.Text = this.dataGridView1.CurrentCell.Value.ToString();
                    this.cboDepartment.Show();
    
                }
            }
    
            private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cboDepartment.Text != "--Select--")
                {
                    DataGridViewCell dgvc = (DataGridViewCell)dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex];
                    dgvc.Value = cboDepartment.Text;
                    cboDepartment.Visible = false;
                    dataGridView1.ClearSelection();
                }
            }
    
            private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
            {
                if (cboDepartment.Visible)
                {
                    if (this.cboDepartment.Location == 
                        this.dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true).Location)
                    {
                        this.cboDepartment.Size = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true).Size;
    
                    }
                }
            }
        }
