	/// <summary>
    /// Reads a table from a spreadsheet.
    /// </summary>
    public sealed class XlsxReader
    {
        /// <summary>
        /// Loads an xlsx file from a filepath into the datatable.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>True if it succeeded, false otherwise.</returns>
        public static DataTable FromXLSX(string filePath)
        {
            try
            {
                // Create the new datatable.
                DataTable dtexcel = new DataTable();
                // Define the SQL for querying the Excel spreadsheet.
                bool hasHeaders = true;
                string HDR = hasHeaders ? "Yes" : "No";
                string strConn;
                // If it is a xlsx file
                if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1;\"";
                else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=1;\"";
                // Create connection
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                // Get scheme
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                // Get sheet name
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    // Query data from the sheet
                    string query = "SELECT  * FROM [" + sheet + "]";
                    OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                    dtexcel.Locale = CultureInfo.CurrentCulture;
                    // Fill the datatable.
                    daexcel.Fill(dtexcel);
                }
                // Close connection.
                conn.Close();
                // Set the datatable.
                return dtexcel;
            }
            catch { throw; }
        }
    }
