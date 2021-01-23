            private void cbCopyToExcel1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            try
            {
                Excel.Range xlRange = xlApp.ActiveCell;
                xlRange.Value = tbProductcode.Text;
            }
            catch 
            {
                MessageBox.Show("Be sure to open an Excel file first");
            }
        }
