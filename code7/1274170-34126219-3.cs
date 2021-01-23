    public partial class frmMainClasses : Form
    {
        //Change 1 
        //I have removed all class level string since they tend to make your code complicated & difficult to manage
        //I'll replace all of them this a single instance of ProductionWorker class, a single object is easy to manage than a bunch 
        ProductionWorker productionWorker = new ProductionWorker(); // Creating the production Worker at class level
        
        public class Employee
        {
            public string EmployeeName { get; set; }
            public int EmployeeNumber { get; set; }
        }
        public class ProductionWorker : Employee
        {
            public float HourlyPayRate { get; set; }
            public Shift Shift { get; set; }
        }
        public enum Shift
        {
            Day = 1,
            Night = 2
        }
        public frmMainClasses()
        {
            InitializeComponent();
        }
        private void btxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            //Change 2 : set the values of the class level variable
            productionWorker.EmployeeName = txtName.Text; //.ToString();  // Change 3 removing the .ToString();
            productionWorker.EmployeeNumber = Convert.ToInt32(txtIdNumb.Text);
            productionWorker.HourlyPayRate = Convert.ToInt32(txtPay.Text);
            productionWorker.Shift = (Shift)Enum.Parse(typeof(Shift), txtShift.Text);
            //change 4 : using .ResetText() instead of Text
            txtName.ResetText();// .Text = "";
            txtIdNumb.ResetText();//.Text = "";
            txtPay.ResetText();//.Text = "";
            txtShift.ResetText();//.Text = "";
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            // change 5 : accessing class level productionWorker instead of bunch of strings
            MessageBox.Show("Name " + productionWorker.EmployeeName + " IDNumber " + productionWorker.EmployeeNumber + " Hourly rate " + productionWorker.HourlyPayRate + " Shift " + productionWorker.Shift);
         }
        
    }
