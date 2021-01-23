        public Dictionary<string,int> GetDictionary(string fullExcelPath)
        {
               //Dictionary<Column Header,Column Index>
        
               Dictionary<string,int> columns=new  Dictionary<string,int>();
        
                 ExcelWorkbook excelWorkbook = ExcelWorkbook.ReadXLSX(fullExcelPath);
        
                 ExcelWorksheet excelWorkSheet = excelWorkbook.Worksheets[0];
        
                 DataTable dataTable = excelWorkSheet.WriteToDataTable();
        
                 DataTable columns=dataTable.Rows[0];
        
                 //iterate to get the column header
            
                 for(int i=0;;i++)
                 {
                    string header=(string )row[i];
                     
                    if(!string.IsNullOrWhiteSpace(header))
                    {
                           columns.Add(header,i);
                    }
                    else
                    {
                       break;
                    }
                 }
               return columns;
        
        }
    
      public void DoWork()
      {
          Dictionary<string,int> columnsFromExcel=GetDictionary(excelPath);
        
          List<string> columnToFilter=GetFromDatabase();
    
          int[] columnIndex=CrossReferenceData(columnsFromExcel,columnToFilter);
    
          //column index=index we wanted to get data from
          //GetDataFromExcel =basically same as GetDictionary but it read from //second row instead of first row and used columnIndex to get data from //dataTable (look GetDictionary method).
          List<string> dataFromExcel=GetDataFromExcel(columnIndex);
    
          DeleteExcelImportTable();
    
          // dynamically created your insert sql
        
          string insertSQL=GetInsertSQL(dataFromExcel);
    
          InsertExcelImportTable(insertSQL);
    
      }
