    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Data.SqlClient;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;
    using System.Data.Odbc;
    using System.Data.OleDb;
    using System.Configuration;
    
    
    public class Form1
    {
    
    
    	private void Button1_Click(System.Object sender, System.EventArgs e)
    	{
    
    		dynamic headers = (from header in DataGridView1.Columns.Cast<DataGridViewColumn>()header.HeaderText).ToArray;
    		dynamic rows = from row in DataGridView1.Rows.Cast<DataGridViewRow>()where !row.IsNewRowArray.ConvertAll(row.Cells.Cast<DataGridViewCell>.ToArray, c => c.Value != null ? c.Value.ToString : "");
    		string str = "";
    		using (IO.StreamWriter sw = new IO.StreamWriter("C:\\Users\\Excel\\Desktop\\OrdersTest.csv")) {
    			sw.WriteLine(string.Join(",", headers));
    			//sw.WriteLine(String.Join(","))
    			foreach (void r_loopVariable in rows) {
    				r = r_loopVariable;
    				sw.WriteLine(string.Join(",", r));
    			}
    			sw.Close();
    		}
    
    	}
    
    	private void Button2_Click(System.Object sender, System.EventArgs e)
    	{
    		//Dim m_strConnection As String = "server='Server_Name';Initial Catalog='Database_Name';Trusted_Connection=True;"
    
    		//Catch ex As Exception
    		//    MessageBox.Show(ex.ToString())
    		//End Try
    
    		//Dim objDataset1 As DataSet()
    		//Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    		//Dim da As OdbcDataAdapter
    		System.Windows.Forms.OpenFileDialog OpenFile = new System.Windows.Forms.OpenFileDialog();
    		// Does something w/ the OpenFileDialog
    		string strFullPath = null;
    		string strFileName = null;
    		TextBox tbFile = new TextBox();
    		// Sets some OpenFileDialog box options
    		OpenFile.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
    		// Shows only .csv files
    		OpenFile.Title = "Browse to file:";
    		// Title at the top of the dialog box
    
    		// Makes the open file dialog box show up
    		if (OpenFile.ShowDialog() == DialogResult.OK) {
    			strFullPath = OpenFile.FileName;
    			// Assigns variable
    			strFileName = Path.GetFileName(strFullPath);
    
    			// Checks to see if they've picked a file
    			if (OpenFile.FileNames.Length > 0) {
    
    				tbFile.Text = strFullPath;
    				// Puts the filename in the textbox
    
    				// The connection string for reading into data connection form
    				string connStr = null;
    				connStr = "Driver={Microsoft Text Driver (*.txt; *.csv)}; Dbq=" + Path.GetDirectoryName(strFullPath) + "; Extensions=csv,txt ";
    
    				// Sets up the data set and gets stuff from .csv file
    				OdbcConnection Conn = new OdbcConnection(connStr);
    				DataSet ds = default(DataSet);
    				OdbcDataAdapter DataAdapter = new OdbcDataAdapter("SELECT * FROM [" + strFileName + "]", Conn);
    				ds = new DataSet();
    
    				try {
    					DataAdapter.Fill(ds, strFileName);
    					// Fills data grid..
    					DataGridView1.DataSource = ds.Tables(strFileName);
    					// ..according to data source
    
    					// Catch and display database errors
    				} catch (OdbcException ex) {
    					OdbcError odbcError = default(OdbcError);
    					foreach ( odbcError in ex.Errors) {
    						MessageBox.Show(ex.Message);
    					}
    				}
    
    				// Cleanup
    				OpenFile.Dispose();
    				Conn.Dispose();
    				DataAdapter.Dispose();
    				ds.Dispose();
    
    			}
    		}
    
    	}
    
    	private void Button3_Click(System.Object sender, System.EventArgs e)
    	{
    		SqlConnection cnn = default(SqlConnection);
    		string connectionString = null;
    		string sql = null;
    
    		connectionString = "data source='Server_Name';" + "initial catalog='Database_Name';Trusted_Connection=True";
    		cnn = new SqlConnection(connectionString);
    		cnn.Open();
    		sql = "SELECT * FROM [Order Details]";
    		SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
    		DataSet ds = new DataSet();
    		dscmd.Fill(ds);
    		DataGridView1.DataSource = ds.Tables(0);
    
    		cnn.Close();
    
    	}
    
    
    	private void ProductsDataGridView_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    	{
    		if (e.ColumnIndex == DataGridView1.Columns(3).Index && e.Value != null) {
    			//
    			if (Convert.ToInt32(e.Value) < 10) {
    				e.CellStyle.BackColor = Color.OrangeRed;
    				e.CellStyle.ForeColor = Color.LightGoldenrodYellow;
    			}
    			//
    		}
    		//
    	}
    
    	//Private Sub ProductsDataGridView_CellFormatting(ByVal sender As Object, _
    	//    ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
    	//        Handles DataGridView1.CellFormatting
    	//    '
    	//    If e.ColumnIndex = DataGridView1.Columns("DataGridViewTextBoxColumn8").Index _
    	//        AndAlso e.Value IsNot Nothing Then
    	//        '
    	//        If CInt(e.Value) < 5 Then
    	//            e.CellStyle.BackColor = Color.OrangeRed
    	//            e.CellStyle.ForeColor = Color.LightGoldenrodYellow
    	//        End If
    	//        '
    	//    End If
    	//    '
    	//End Sub
    
    
    	//If e.ColumnIndex = ProductsDataGridView.Columns(4).Index _
    	//AndAlso e.Value IsNot Nothing Then
    	//'
    	//    If CInt(e.Value) = 0 Then
    	//        e.CellStyle.BackColor = Color.OrangeRed
    	//        e.CellStyle.ForeColor = Color.LightGoldenrodYellow
    	//    End If
    	//End If
    
    	// ''To (you need to change the column name)
    	//    If e.ColumnIndex = ProductsDataGridView.Columns("YourColumnName").Index _
    	//    AndAlso e.Value IsNot Nothing Then
    	//'
    	//    If CInt(e.Value) = 0 Then
    	//        e.CellStyle.BackColor = Color.OrangeRed
    	//        e.CellStyle.ForeColor = Color.LightGoldenrodYellow
    	//    End If
    	//End If
    
    
    	private void Button4_Click(System.Object sender, System.EventArgs e)
    	{
    		DataTable tblReadCSV = new DataTable();
    
    		tblReadCSV.Columns.Add("FName");
    		tblReadCSV.Columns.Add("LName");
    		tblReadCSV.Columns.Add("Department");
    
    		TextFieldParser csvParser = new TextFieldParser("C:\\Users\\Excel\\Desktop\\Employee.txt");
    
    		csvParser.Delimiters = new string[] { "," };
    		csvParser.TrimWhiteSpace = true;
    		csvParser.ReadLine();
    
    		while (!(csvParser.EndOfData == true)) {
    			tblReadCSV.Rows.Add(csvParser.ReadFields());
    		}
    
    		SqlConnection con = new SqlConnection("Server='Server_Name';Database='Database_Name';Trusted_Connection=True;");
    		string strSql = "Insert into Employee(FName,LName,Department) values(@Fname,@Lname,@Department)";
    		//Dim con As New SqlConnection(strCon)
    		SqlCommand cmd = new SqlCommand();
    		cmd.CommandType = CommandType.Text;
    		cmd.CommandText = strSql;
    		cmd.Connection = con;
    		cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 50, "FName");
    		cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 50, "LName");
    		cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50, "Department");
    
    		SqlDataAdapter dAdapter = new SqlDataAdapter();
    		dAdapter.InsertCommand = cmd;
    		int result = dAdapter.Update(tblReadCSV);
    
    	}
    
    
    	private void Button5_Click(System.Object sender, System.EventArgs e)
    	{
    		string SQLConnectionString = "Data Source=Excel-PC\\SQLEXPRESS;" + "Initial Catalog=Northwind;" + "Trusted_Connection=True";
    
    		// Open a connection to the AdventureWorks database.
    		using (SqlConnection SourceConnection = new SqlConnection(SQLConnectionString)) {
    			SourceConnection.Open();
    
    			// Perform an initial count on the destination table.
    			SqlCommand CommandRowCount = new SqlCommand("SELECT COUNT(*) FROM dbo.Orders;", SourceConnection);
    			long CountStart = System.Convert.ToInt32(CommandRowCount.ExecuteScalar());
    			Console.WriteLine("Starting row count = {0}", CountStart);
    
    			// Get data from the source table as a AccessDataReader.
    			//Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    			//    "Data Source=" & "C:\Users\Excel\Desktop\OrdersTest.txt" & ";" & _
    			//    "Extended Properties=" & "text;HDR=Yes;FMT=Delimited"","";"
    
    			string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + "C:\\Users\\Excel\\Desktop\\" + ";" + "Extended Properties=\"Text;HDR=No\"";
    
    			System.Data.OleDb.OleDbConnection TextConnection = new System.Data.OleDb.OleDbConnection(ConnectionString);
    
    			OleDbCommand TextCommand = new OleDbCommand("SELECT * FROM OrdersTest#csv", TextConnection);
    			TextConnection.Open();
    			OleDbDataReader TextDataReader = TextCommand.ExecuteReader(CommandBehavior.SequentialAccess);
    
    			// Open the destination connection.              
    			using (SqlConnection DestinationConnection = new SqlConnection(SQLConnectionString)) {
    				DestinationConnection.Open();
    
    				// Set up the bulk copy object. 
    				// The column positions in the source data reader 
    				// match the column positions in the destination table, 
    				// so there is no need to map columns.
    				using (SqlBulkCopy BulkCopy = new SqlBulkCopy(DestinationConnection)) {
    					BulkCopy.DestinationTableName = "dbo.Orders";
    
    					try {
    						// Write from the source to the destination.
    						BulkCopy.WriteToServer(TextDataReader);
    
    					} catch (Exception ex) {
    						Console.WriteLine(ex.Message);
    
    					} finally {
    						// Close the AccessDataReader. The SqlBulkCopy
    						// object is automatically closed at the end
    						// of the Using block.
    						TextDataReader.Close();
    					}
    				}
    
    				// Perform a final count on the destination table
    				// to see how many rows were added.
    				long CountEnd = System.Convert.ToInt32(CommandRowCount.ExecuteScalar());
    				//Console.WriteLine("Ending row count = {0}", CountEnd)
    				//Console.WriteLine("{0} rows were added.", CountEnd - CountStart)
    			}
    		}
    
    
    		//Dim FILE_NAME As String = "C:\Users\Excel\Desktop\OrdersTest.csv"
    		//Dim TextLine As String
    
    		//If System.IO.File.Exists(FILE_NAME) = True Then
    		//    Dim objReader As New System.IO.StreamReader(FILE_NAME)
    		//    Do While objReader.Peek() <> -1
    		//        TextLine = TextLine & objReader.ReadLine() & vbNewLine
    		//    Loop
    		//Else
    		//    MsgBox("File Does Not Exist")
    		//End If
    
    		//Dim cn As New SqlConnection("Data Source=Excel-PC\SQLEXPRESS;Initial Catalog=Northwind;Trusted_Connection=True;")
    		//Dim cmd As New SqlCommand
    
    		//cmd.Connection = cn
    
    		//cmd.Connection.Close()
    		//cmd.Connection.Open()
    
    		//cmd.CommandText = "INSERT INTO Orders (OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) values & OrdersTest.csv"
    		//cmd.ExecuteNonQuery()
    		//cmd.Connection.Close()
    
    	}
    
    
    	private void Button6_Click(System.Object sender, System.EventArgs e)
    	{
    		// Define the Column Definition                             
    		DataTable dt = new DataTable();
    		dt.Columns.Add("OrderID", typeof(int));
    		dt.Columns.Add("CustomerID", typeof(string));
    		dt.Columns.Add("EmployeeID", typeof(int));
    		dt.Columns.Add("OrderDate", typeof(System.DateTime));
    		dt.Columns.Add("RequiredDate", typeof(System.DateTime));
    		dt.Columns.Add("ShippedDate", typeof(System.DateTime));
    		dt.Columns.Add("ShipVia", typeof(int));
    		dt.Columns.Add("Freight", typeof(decimal));
    		dt.Columns.Add("ShipName", typeof(string));
    		dt.Columns.Add("ShipAddress", typeof(string));
    		dt.Columns.Add("ShipCity", typeof(string));
    		dt.Columns.Add("ShipRegion", typeof(string));
    		dt.Columns.Add("ShipPostalCode", typeof(string));
    		dt.Columns.Add("ShipCountry", typeof(string));
    		using (cn == new SqlConnection("Server='Server_Name';Database='Database_Name';Trusted_Connection=True;")) {
    			cn.Open();
    			Microsoft.VisualBasic.FileIO.TextFieldParser reader = default(Microsoft.VisualBasic.FileIO.TextFieldParser);
    			string[] currentRow = null;
    			DataRow dr = default(DataRow);
    			string sqlColumnDataType = null;
    			reader = My.Computer.FileSystem.OpenTextFieldParser("C:\\Users\\Excel\\Desktop\\OrdersTest.csv");
    			reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
    			reader.Delimiters = new string[] { "," };
    			while (!reader.EndOfData) {
    				try {
    					currentRow = reader.ReadFields();
    					dr = dt.NewRow();
    					for (currColumn = 0; currColumn <= dt.Columns.Count - 1; currColumn++) {
    						sqlColumnDataType = dt.Columns(currColumn).DataType.Name;
    						switch (sqlColumnDataType) {
    							case "String":
    								if (string.IsNullOrEmpty(currentRow(currColumn))) {
    									dr.Item(currColumn) = "";
    								} else {
    									dr.Item(currColumn) = Convert.ToString(currentRow(currColumn));
    								}
    								break;
    							case "Decimal":
    								if (string.IsNullOrEmpty(currentRow(currColumn))) {
    									dr.Item(currColumn) = 0;
    								} else {
    									dr.Item(currColumn) = Convert.ToDecimal(currentRow(currColumn));
    								}
    								break;
    							case "DateTime":
    								if (string.IsNullOrEmpty(currentRow(currColumn))) {
    									dr.Item(currColumn) = "";
    								} else {
    									dr.Item(currColumn) = Convert.ToDateTime(currentRow(currColumn));
    								}
    								break;
    						}
    					}
    					dt.Rows.Add(dr);
    				} catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex) {
    					Interaction.MsgBox("Line " + ex.Message + "is not valid." + Constants.vbCrLf + "Terminating Read Operation.");
    					reader.Close();
    					reader.Dispose();
    					//Return False
    				} finally {
    					dr = null;
    				}
    			}
    			using (SqlBulkCopy copy = new SqlBulkCopy(cn)) {
    				copy.DestinationTableName = "[dbo].[Orders]";
    				copy.WriteToServer(dt);
    			}
    		}
    
    	}
    
    
    	public static bool GetCsvData(string CSVFileName, ref DataTable CSVTable)
    	{
    		Microsoft.VisualBasic.FileIO.TextFieldParser reader = default(Microsoft.VisualBasic.FileIO.TextFieldParser);
    		string[] currentRow = null;
    		DataRow dr = default(DataRow);
    		string sqlColumnDataType = null;
    		reader = My.Computer.FileSystem.OpenTextFieldParser(CSVFileName);
    		reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
    		reader.Delimiters = new string[] { "," };
    		while (!reader.EndOfData) {
    			try {
    				currentRow = reader.ReadFields();
    				dr = CSVTable.NewRow();
    				for (currColumn = 0; currColumn <= CSVTable.Columns.Count - 1; currColumn++) {
    					sqlColumnDataType = CSVTable.Columns(currColumn).DataType.Name;
    					switch (sqlColumnDataType) {
    						case "String":
    							if (string.IsNullOrEmpty(currentRow(currColumn))) {
    								dr.Item(currColumn) = "";
    							} else {
    								dr.Item(currColumn) = Convert.ToString(currentRow(currColumn));
    							}
    							break;
    						case "Decimal":
    							if (string.IsNullOrEmpty(currentRow(currColumn))) {
    								dr.Item(currColumn) = 0;
    							} else {
    								dr.Item(currColumn) = Convert.ToDecimal(currentRow(currColumn));
    							}
    							break;
    						case "DateTime":
    							if (string.IsNullOrEmpty(currentRow(currColumn))) {
    								dr.Item(currColumn) = "";
    							} else {
    								dr.Item(currColumn) = Convert.ToDateTime(currentRow(currColumn));
    							}
    							break;
    					}
    				}
    				CSVTable.Rows.Add(dr);
    			} catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex) {
    				Interaction.MsgBox("Line " + ex.Message + "is not valid." + Constants.vbCrLf + "Terminating Read Operation.");
    				reader.Close();
    				reader.Dispose();
    				return false;
    			} finally {
    				dr = null;
    			}
    		}
    		reader.Close();
    		reader.Dispose();
    		return true;
    	}
    }
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================
