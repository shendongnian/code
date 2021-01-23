    using(ExcelPackage p = new ExcelPackage()) {
    	ExcelWorksheet ws = p.Workbook.Worksheets[1];
    	ws.Name = "data1";
    	
    	//Starting cell
    	int startRow = 1;
    	int startCol = 1;
    
        //Needed for 2D object array later on
        int maxColCount = 0;
        int maxRowCount = 0;
        
        //Queue data
        Queue<string[]> dataQueue = new Queue<string[]>();
        
        //Tried not to touch this part
    	foreach(var element in StreamElements(pa, "XML")) {
    		var values = element.DescendantNodes().OfType<XText>()
    			.Select(v = > Regex.Replace(v.Value, "\\s+", " "));
    			
    		//Removed unnecessary split and join, use ToArray instead
    		string[] eData = values.ToArray();
    		eData[2] = toDateTime(eData[2]);
    		
    		//Push the data to queue and increment counters (if needed)
    		dataQueue.Enqueue(eData);
    		
            if(eData.Length > maxColCount)
                maxColCount = eData.Length;
                
    		maxRowCount++;
    	}
    	
    	//We now have the dimensions needed for our object array
    	object[,] excelArr = new object[maxRowCount, maxColCount];
    	
    	//Dequeue data from Queue and populate object matrix
    	int i = 0;
    	while(dataQueue.Count > 0){
    	    string[] eData = dataQueue.Dequeue();
    	    
    	    for(int j = 0; j < eData.Length; j++){
    	        excelArr[i, j] = eData[j];
    	    }
    	    
    	    i++;
    	}
    	
    	//Write data to range
        Excel.Range c1 = (Excel.Range)wsh.Cells[startRow, startCol];
        Excel.Range c2 = (Excel.Range)wsh.Cells[startRow + maxRowCount - 1, maxColCount];
        Excel.Range range = wsh.get_Range(c1, c2);
    
        range.Value = excelArr;
        
        //Tried not to touch this stuff
        ws.Cells[ws.Dimension.Address].AutoFitColumns();
        
        Byte[] bin = p.GetAsByteArray();
        using(FileStream fs = File.OpenWrite("C:\\test.xlsx")) {
        	fs.Write(bin, 0, bin.Length);
        }
    }
