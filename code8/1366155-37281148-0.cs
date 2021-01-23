    using Microsoft.Office.Excel.Interop;
    namespace XYZ
    {
        public partial class ABC : Form
        {
        Excel.Range activecell = null;
        Excel.Application xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        public ABC()
        {
        InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (xlApp.Selection is Excel.Range)
            {
                activecell = xlApp.Selection as Excel.Range;
                //Return value to winform textbox
                txtSearchPattern.Text = activecell.Value2.ToString();
            }
        }
    }
    }
