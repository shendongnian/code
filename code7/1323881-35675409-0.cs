    // Put this in the namespace references sections
    using Excel = Microsoft.Office.Interop.Excel;
    
    
    //inside your class(es) that will be writing to Excel
    Excel.Application xlApp; //instance of the Excel application
    Excel._Workbook xlWB; //will become the workbook object of the Excel application
    Excel._WorkSheet xlWS; //will become the worksheet object of the Excel application
    object misval = System.Reflection.Missing.Value; //used to cover certain arguements for saving (as far as I gather)
    
    public void ExcelWriter()
    {
    	xlApp = new Excel.Application; //starts an instance of Excel
    	xlApp.Visible = false; //hides the application from appearing on screen
    	xlApp.Dialog = false; //keeps the "Save As" dialogs from appearing when it goes to save
    	
    	//adds a new workbook to the Excel application and puts a new sheet in it
    	xlWB = (Excel._Workbook)(xlApp.Workbooks.Add("Name of Book Goes Here"));//your workbook instance
    	xlWS = (Excel._WorkSheet)xlWS.ActiveSheet;//your worksheet instance
    	
    	
    	//each cell is referenced along an array
    	//for example, cell A1 is 1,1
    	xlWS.Cells[1,1] = label1.Text;
    	xlWS.Cells[1,2] = label2.Text;
    	xlWS.Cells[1,3] = label3.Text;
    	xlWS.Cells[1,4] = label4.Text;
    	.....
    	//whatever executable code you'd like here
    	//formatting of cells, fonts, etc.
    	
    	xlWB.SaveAs("C:\\Path\Goes\Here", misval, misval, misval,
    				misval, misval, misval, misval, misval,
    				misval, misval, misval, misval);
    	xlWB.Close();
    	xlApp.Quit();
    }
