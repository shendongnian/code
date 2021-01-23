    public partial class Form1 : Form
    {
    	public Form1()
        {
            InitializeComponent();
    	}
    
        private void buttonOpenForm3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
    		frm3.RecordAdded += Form3_RecordAdded;
            frm3.Show();
        }
    	
    	private void Form3_RecordAdded(object sender, AddRecordEventArgs e) {
    		// Access e.Quantity, e.Description and e.Price
            // and add new row in grid using these values.
    	}
    }
