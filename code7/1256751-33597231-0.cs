    public class FormClick : Form {
    
    	DataGridView dgv = new DataGridView { Dock = DockStyle.Fill };
    	DataTable table = new DataTable();
    
    	public FormClick() {
    		table.Columns.Add("A");
    		table.Columns.Add("B");
    		dgv.DataSource = table;
    		Controls.Add(dgv);
    
    		dgv.CellEndEdit += dgv_CellEndEdit;
    	}
    
    	void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
    		
    		DataRow row = ((DataRowView) dgv.Rows[e.RowIndex].DataBoundItem).Row;
    		bool allEmpty = true;
    		for (int i = 0; i < table.Columns.Count; i++) {
    			String s = row[i].ToString();
    			if (s.Length > 0) {
    				allEmpty = false;
    				break;
    			}
    		}
    		if (allEmpty) {
    			dgv.Rows.RemoveAt(e.RowIndex);
    		}
    	}
    }
