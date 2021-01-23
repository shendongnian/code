     public void WriteData<T>(ref ExcelWorksheet workSheet,List<T> list)
        {
            
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            ...
			...
			...
                
            foreach(T item in list)
            {
                System.Reflection.PropertyInfo[] propertyInfo = item.GetType().GetProperties();
                
                int cellIndex = 1;
                workSheet.Column(cellIndex).AutoFit();
                foreach (System.Reflection.PropertyInfo info in propertyInfo)
                {
                    object value = info.GetValue(item, null);
                    workSheet.Cells[recordIndex, cellIndex++].Value = value;
                }
                
                recordIndex++;
            }
        } 
