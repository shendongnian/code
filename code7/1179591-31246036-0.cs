    public class ChildForm : Form
    {
        // FIELDS
        private string customerName;
        private string customerCode;
        
        // PROPERTIES
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        
        public string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }
        // FORM CLOSING
        private void ChildForm_FormClosing(object sender, EventArgs e)
        {
            // SET VALUES
            this.customerName = "name";
            this.customerCode = "012345";
        }
    }
