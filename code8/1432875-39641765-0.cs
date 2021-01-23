    Thread.Sleep(100);
    
    wSheet.get_Range(...).Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
    
    Thread.Sleep(100);    
                        
    wSheet.get_Range(...).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlHairline);
    
    Thread.Sleep(100); 
    
    wSheet.get_Range(...).Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                       
