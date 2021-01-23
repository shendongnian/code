    // get Excel file that should be imported
    string strFilePath = "";
    this.openFileDialog.Title = "Select Excel File For Importing";
    this.openFileDialog.Filter = "Excel Files|*.xls;";
    this.openFileDialog.CheckFileExists = true;
    this.openFileDialog.Multiselect = false;
    this.openFileDialog.ShowDialog();
    strFilePath = this.openFileDialog.FileName;
    this.txtExcelFileName.Text = this.openFileDialog.FileName;
    
    string strConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;\"";
    System.Data.OleDb.OleDbDataAdapter dataAdapterExcel = new System.Data.OleDb.OleDbDataAdapter();
    System.Data.OleDb.OleDbConnection oledbConnection = new System.Data.OleDb.OleDbConnection(strConnectionString);
    DataTable tblEnglishTab = new DataTable("English");
    DataTable tblMetricTab = new DataTable("Metric");
    DataSet datasetExcelData = new DataSet();
    
    oledbConnection.Open();
    System.Data.OleDb.OleDbCommand cmdselect = new System.Data.OleDb.OleDbCommand();
    
    try
    {
    	cmdselect.CommandText = "SELECT * FROM [English$A1:N10000]";
        cmdselect.Connection = oledbConnection;
    	dataAdapterExcel.SelectCommand = cmdselect;
    	dataAdapterExcel.Fill(tblEnglishTab);
        datasetExcelData.Tables.Add(tblEnglishTab);
    }    
    catch (Exception)
    {
    	MessageBox.Show("Please verify the Excel file type.\nUnable to locate the English worksheet in the specified file."Excel Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }    
    try
    {
    	cmdselect.CommandText = "SELECT * FROM [Metric$A1:N10000]";
    	cmdselect.Connection = oledbConnection;
    	dataAdapterExcel.SelectCommand = cmdselect;
    	dataAdapterExcel.Fill(tblMetricTab);
    	datasetExcelData.Tables.Add(tblMetricTab);
    }
    catch (Exception)
    {
    	MessageBox.Show("Please verify the Excel file type.\nUnable to locate the Metric worksheet in the specified file.", "Excel Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    oledbConnection.Close();
    dataAdapterExcel = null;
