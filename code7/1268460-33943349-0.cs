    public partial class Form3 : Form
    {
    	public event EventHandler<AddRecordEventArgs> RecordAdded
    	
        public Form3()
        {
            InitializeComponent();
        }
    
        private void buttonAddRow _Click(object sender, EventArgs e)
        {
    		OnRecordAdded();
        }
    	
    	private void OnRecordAdded() {
    		var handler = RecordAdded;
    		if(RecordAdded != null) {
    			RecordAdded.Invoke(this, new AddRecordEventArgs(txtQty.Text, txtDesc.Text, txtPrice.Text))
    		}
    	}
    }
