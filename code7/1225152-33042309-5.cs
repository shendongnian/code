    private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            Excel.Workbook wkbk = null;
            wkbk = xlApp.ActiveWorkbook;
            FocusProcess("Excel"); 
            try
            {
                Excel.Range address = xlApp.Application.InputBox("Select a Range", "Model Cutter 64", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 8);
                txtWkshtName.Text = address.Parent.Name;
                txtRange.Text = address.get_Address(address);
            }
            catch
            {
                errorMessage("A valid range was not selected., please try again.");
                FocusProcess("Model Cutter 64.vshost");
            }
            FocusProcess("Model Cutter 64.vshost");
        }
