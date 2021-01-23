    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Range xlRange = xlApp.ActiveCell;
            xlRange.Value = textBox1.Text;
        }
