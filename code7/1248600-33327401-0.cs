    public class StockInfo {
    	public String Symbol;
    	public decimal Price;
    	public decimal Change;
    }
    
    public class StockForm : Form {
    
    	SprawlingDGV dgv = new SprawlingDGV();
    
    	public StockForm() {
    		Controls.Add(dgv);
    	}
    
    }
    
    public class SprawlingDGV : DataGridView {
    
    	DataTable table = new DataTable();
    	int previousNumRowsAvailable = -1;
    	public List<StockInfo> StockData = new List<StockInfo>();
    
    	public SprawlingDGV() {
    		Dock = DockStyle.Fill;
    		DataSource = table;
    		AllowUserToAddRows = false;
    
    		for (int i = 0; i < 50; i++) {
    			StockInfo s = new StockInfo();
    			s.Symbol = "Symbol" + i;
    			s.Price = i;
    			StockData.Add(s);
    		}
    	}
    
    	protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e) {
    		base.OnCellFormatting(e);
    		// TBD: Hide the grid lines for unused cells
    		if (e.Value == DBNull.Value)
    			e.CellStyle.BackColor = Color.DarkGray;
    	}
    
    	protected override void OnResize(EventArgs e) {
    		base.OnResize(e);
    
    		DataTable table2 = new DataTable();
    		var col1 = table2.Columns.Add("Symbol_0", typeof(String));
    		var col2 = table2.Columns.Add("Price_0", typeof(decimal));
    		var col3 = table2.Columns.Add("Change_0", typeof(decimal));
    		int heightPerRow = 30; // TBD: determine height based on Font
    		int numRowsAvailable = (this.Height - this.ColumnHeadersHeight) / heightPerRow;
    		if (numRowsAvailable == previousNumRowsAvailable)
    			return;
    		previousNumRowsAvailable = numRowsAvailable;
    		int n = Math.Max(1, numRowsAvailable);
    		int id = 0;
    		for (int i = 0, k = 0; i < StockData.Count; i++) {
    			StockInfo s = StockData[i];
    			DataRow row = null;
    			if (id == 0) {
    				row = table2.NewRow();
    				table2.Rows.Add(row);
    			}
    			else {
    				row = table2.Rows[k];
    			}
    
    			row[col1] = s.Symbol;
    			row[col2] = s.Price;
    			row[col3] = s.Change;
    
    			k++;
    			if (k == n) {
    				k = 0;
    				id++;
    				col1 = table2.Columns.Add("Symbol_" + id, typeof(String));
    				col2 = table2.Columns.Add("Price_" + id, typeof(decimal));
    				col3 = table2.Columns.Add("Change_" + id, typeof(decimal));
    			}
    		}
    
    		DataSource = table2;
    		table.Dispose();
    		table = table2;
    		foreach (DataGridViewColumn c in Columns) {
    			String t = c.HeaderText;
    			int x = t.IndexOf('_');
    			if (x < 0)
    				continue;
    			c.HeaderText = t.Substring(0, x);
    		}
    	}
    }
