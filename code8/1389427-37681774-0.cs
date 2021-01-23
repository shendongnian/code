    public partial class Form1 : Form
    {
        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel._Workbook oWB;
        Microsoft.Office.Interop.Excel._Worksheet oSheet;
        Microsoft.Office.Interop.Excel.Range oRng;
        int num;
    
        public Form1()
        {
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
    
            oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
            oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
    
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            // here you create the Headers once the Form is loaded
            initHeaders();
        }
        // a Method to create the Headers in the file
        private void initHeaders()
        {
            oSheet.Cells[1, 1] = "UserName";
            oSheet.Cells[1, 2] = "Workstation Name";
            oSheet.Cells[1, 3] = "Manufacturer";
            oSheet.Cells[1, 4] = "Model";
            oSheet.Cells[1, 5] = "Serial";
            oSheet.Cells[1, 6] = "CPU";
            oSheet.Cells[1, 7] = "RAM";
            oSheet.Cells[1, 8] = "OS";
            oSheet.Cells[1, 9] = "Version";
            oSheet.Cells[1, 10] = "Microsoft Office";
            oSheet.Cells[1, 11] = "Recommendations";
            oSheet.Cells[1, 12] = "Comments";
    
            oSheet.get_Range("A1", "L1").Font.Bold = true;
            oSheet.get_Range("A1", "L1").VerticalAlignment =
            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            num++;
    
            // you actually need only a one dimensional array    
            string[] saNames = new string[13];
    
            saNames[0] = txtUsername1.Text;
            saNames[1] = txtWorkName1.Text;
            saNames[2] = cbxManufac.Text;
            saNames[3] = cbxMachType.Text;
            saNames[4] = txtModel.Text;
            saNames[5] = txtSerial.Text;
            saNames[6] = txtCPU.Text;
            saNames[7] = cbxRAM.Text;
            saNames[8] = cbxOS.Text;
            saNames[9] = txtVersion.Text;
            saNames[10] = txtMcstOffice.Text;
            saNames[11] = txtRecomend.Text;
            saNames[12] = txtComments.Text;
    
            // Try to increment just the position in the file
            string startposition = "A" + num.toString();
            oSheet.get_Range(startposition , "L1000").Value = saNames;
        }
    }
