    private DataGridView childDgv = new DataGridView();
    
    private void Form1_Load(object sender, EventArgs e)
    {
    	parentDgv.CellClick += parentDgv_CellClick;
    	parentDgv.Columns["DCS (Hz)"].ReadOnly = true; // uneditable
    
    	Set10x10Data(childDgv);　// set 10 x 10 data to the child DataGridView
    	childDgv.ColumnHeadersVisible = false;
    	childDgv.RowHeadersVisible = false;
    
    	childDgv.CellClick += childDgv_CellClick;
    	childDgv.Visible = false;
    
    	parentDgv.Controls.Add(childDgv);
    }
    
    void parentDgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
    	if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "DCS (Hz)")
    	{
    		// Show child DataGridView under the clicked cell
    		Rectangle dgvRectangle = parentDgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
    		childDgv.Location = new Point(dgvRectangle.X, dgvRectangle.Y + 20);
    		childDgv.CurrentCell = childDgv[0, 0];
    		childDgv.Visible = true;
    	}
    }
    
    void childDgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
    	parentDgv.CurrentCell.Value = childDgv[e.ColumnIndex, e.RowIndex].Value;
    	childDgv.Visible = false;
    }
