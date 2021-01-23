                try
                {           
                //Get active excel instance
                Excel.Application xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    
                //Get active excel workbook
                Excel.Workbook xlWorkBook = (Excel.Workbook)xlApp.ActiveWorkbook;
    
                //Get active excel worksheet
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.ActiveSheet;
                
                //Get value for excel          
                string AValue = xlApp.ActiveCell.Value2.ToString();
    
                //Return value to winform textbox
                txtSearchPattern.Text = AValue;    
                }
                catch(NullReferenceException)
                {
                    MessageBox.Show("ActiveCell was null");
                }
