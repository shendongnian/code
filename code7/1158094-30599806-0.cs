    //...code above
    
    datasheet.Range["A2:GT999"].ClearContents();  
    
    pivot.UsedRange.Copy();
    
    datasheet.Range["A2"].PasteSpecial(xl.XlPasteType.xlPasteValues, 
                                       xl.XlPasteSpecialOperation.xlPasteSpecialOperationNone, 
                                       System.Type.Missing, System.Type.Missing);                                   
    //code below...
