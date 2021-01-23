    public partial class AlternativeToCellEndEdit : Form
    {
    	public AlternativeToCellEndEdit()
    	{
    		InitializeComponent();
    		dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
    	}
    	// Try handling CellValueChanged instead of CellEndEdit
    	private void DataGridView1_CellValueChanged(Object sender, DataGridViewCellEventArgs e)
    	{
    		// Our MyRecord class is smart and makes the calculation
    		// any time we change Quantity or Amt. Here, we only need 
    		// to refresh the DataGridView to show the updated info.
    		dataGridView1.Refresh();
    	}
    	// Make a class to represent a line item in the DataGridView.
    	// When the Quantity or Amt changes, it recalculates itself.
    	class MyRecord
    	{
    		public string Description { get; set; } = "New Item";
    		int mQuantity = 1;
    		public int Quantity
    		{
    			get { return mQuantity; }
    			set { mQuantity = value;  NetPrice = Quantity * Amt; }	// Recalc
    		}
    		double mAmt = 0.00;
    		public double Amt
    		{
    			get { return mAmt; }
    			set { mAmt = value; NetPrice = Quantity * Amt; }        // Recalc
    		}
    		public double NetPrice { get; private set; } // Makes this cell Read-Only in the DataGridView
    	}
    	// Tell the DataGridView that we want to display our custom class.
    	BindingList<MyRecord> Items = new BindingList<MyRecord>();
    	protected override void OnHandleCreated(EventArgs e)
    	{
    		base.OnHandleCreated(e);
    		// Bind data to the view.
    		// Now DataGridView does all the work for us.
    		dataGridView1.DataSource = Items;
    		// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    
    		// Make everything look nice in the way of formatting.
    		DataGridViewColumn col;
    		col = dataGridView1.Columns["Description"];
    		col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    		col = dataGridView1.Columns["Quantity"];
    		col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    		col = dataGridView1.Columns["Amt"];
    		col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    		col.DefaultCellStyle.Format = "F2";
    		col = dataGridView1.Columns["NetPrice"];
    		col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    		col.DefaultCellStyle.Format = "F2";
    		// Add the first default item
    		Items.Add(new MyRecord());
    	}
    }
