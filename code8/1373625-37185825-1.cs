    #region Properties
        public string Directory { get; set; }
        public string FirstFile { get; set; }
        public string FirstFileSheetName { get; set; }
        public string SecondFile { get; set; }
        public string SecondFileSheetName { get; set; }
        public DataTable ReturnDataSet { get; set; }
        public bool Excel2007 { get; set; }
        public bool UseHeader { get; set; }
    #endregion
    #region Constructor
        public ExcelHandler() { }
        public ExcelHandler(string Dir, string File1, string File1SheetName, string File2, string File2SheetName)
        {
            this.Directory = Dir;
            this.FirstFile = File1;
            this.SecondFile = File2;
            this.FirstFileSheetName = File1SheetName;
            this.SecondFileSheetName = File2SheetName;
        }
    #endregion
        #region Match Files
        public DataTable CheckExcelFiles()
        {
            DataTable dtRet = new DataTable();
            //Read the first excel
            try
            {
                //Read the excel
                DataTable dt1 = GetDataTableFromExcel(this.Directory, this.FirstFile, this.FirstFileSheetName);
                DataTable dt2 = GetDataTableFromExcel(this.Directory, this.SecondFile, this.SecondFileSheetName);
                //Compare two
                dtRet = getDifferentRecords(dt1, dt2);
            }
            catch (Exception ex) { }
            return dtRet;
        }
        //Overload method to write to csv
        public void CheckExcelFiles(string strFilePath)
        {
            DataTable dtRet = new DataTable();
            //Read the first excel
            try
            {
                //Read the excel
                DataTable dt1 = GetDataTableFromExcel(this.Directory, this.FirstFile, this.FirstFileSheetName);
                DataTable dt2 = GetDataTableFromExcel(this.Directory, this.SecondFile, this.SecondFileSheetName);
                //Compare two
                dtRet = getDifferentRecords(dt1, dt2);
                ExportDataTableToExcel(dtRet, strFilePath);
            }
            catch (Exception ex) { }
            
        }
        //Get Datatable reading Excel
        private DataTable GetDataTableFromExcel(string strDir, string strFileName, string strSheetName)
        {
            var fileName = string.Format("{0}\\" + strFileName, strDir);
            string connectionString;
            if (Excel2007)
                //read a 2007 file  
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=" + (UseHeader == true ? "YES" : "NO") + ";\"", fileName);
            else
                //read a 97-2003 file  
                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=" + (UseHeader == true ? "YES" : "NO") + ";\"", fileName);  
            
            //var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
            var adapter = new OleDbDataAdapter("SELECT * FROM [" + strSheetName + "$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, fileName + strSheetName);
            return ds.Tables[fileName + strSheetName];
        }
        //Compare datatables
        private DataTable CompareDataTable(DataTable A, DataTable B)
        {
            A.PrimaryKey = new DataColumn[] { A.Columns["PK"] };
            B.PrimaryKey = new DataColumn[] { B.Columns["PK"] };
            A.Merge(B, true); // this will add to A any records that are in B but not A 
            A.AcceptChanges();
            return A.GetChanges(DataRowState.Added); // returns records originally only in B
        }
        //Provided here http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/23703a85-20c7-4759-806a-fabf4e9f5be6/
        //Provided by Guo Surfer
        #region Compare two DataTables and return a DataTable with DifferentRecords  
        /// <summary>  
        /// Compare two DataTables and return a DataTable with DifferentRecords  
        /// </summary>  
        /// <param name="FirstDataTable">FirstDataTable</param>  
        /// <param name="SecondDataTable">SecondDataTable</param>  
        /// <returns>DifferentRecords</returns>  
        public DataTable getDifferentRecords(DataTable FirstDataTable, DataTable SecondDataTable)
        {
            //Create Empty Table  
            DataTable ResultDataTable = new DataTable("ResultDataTable");
            //use a Dataset to make use of a DataRelation object  
            using (DataSet ds = new DataSet())
            {
                //Add tables  
                ds.Tables.AddRange(new DataTable[] { FirstDataTable.Copy(), SecondDataTable.Copy() });
                //Get Columns for DataRelation  
                DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                for (int i = 0; i < firstColumns.Length; i++)
                {
                    firstColumns[i] = ds.Tables[0].Columns[i];
                }
                DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                for (int i = 0; i < secondColumns.Length; i++)
                {
                    secondColumns[i] = ds.Tables[1].Columns[i];
                }
                //Create DataRelation  
                DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                ds.Relations.Add(r1);
                DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                ds.Relations.Add(r2);
                //Create columns for return table  
                for (int i = 0; i < FirstDataTable.Columns.Count; i++)
                {
                    ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);
                }
                //If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.  
                ResultDataTable.BeginLoadData();
                foreach (DataRow parentrow in ds.Tables[0].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r1);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }
                //If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.  
                foreach (DataRow parentrow in ds.Tables[1].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r2);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }
                ResultDataTable.EndLoadData();
            }
            return ResultDataTable;
        }
        
        #endregion  
        private void ExportDataTableToExcel(DataTable dt, string strFilePath)
        {
        // Create the CSV file to which grid data will be exported.
        StreamWriter sw = new StreamWriter(strFilePath, false);
        // First we will write the headers.
        //DataTable dt = m_dsProducts.Tables[0];
        int iColCount = dt.Columns.Count;
        for (int i = 0; i < iColCount; i++)
        {
            sw.Write(dt.Columns[i]);
            if (i < iColCount - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write(sw.NewLine);
        // Now write all the rows.
        foreach (DataRow dr in dt.Rows)
        {
            for (int i = 0; i < iColCount; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    sw.Write(dr[i].ToString());
                }
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
 
        }
    
        #endregion
