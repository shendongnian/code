    private static ReadRows(string SearchValue, int StartRow)
    {
        int r = StartRow;
        Excel.Application xl = new Excel.Application();
        xl.Workbooks.Open(your workbook);
        Excel.WorkSheet ws = xl.Workbooks(1).Worksheets(1);
    
        do
	    {
            if(ws.Cells(r,3).value == SearchValue)
            {
                // read the entire row
                string colA = ws.Cells(r,1).value;
                string colB = ws.Cells(r,2).value;
                //...
    
                // or loop through all columns 
                int c = 1;
                do
	            {
	                // add cell value to some collection
	                c++;
	            } while (ws.Cells(r,c).Value != "");
            }
	        r++;
	    } while (ws.Cells(r,3).Value != "");   // 3 because you want column C
    }
