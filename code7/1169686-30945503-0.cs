	try {
		DataTable ExcelSheets = m_connexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] {
			null,
			null,
			null,
			"TABLE"
		});
		foreach (DataRow row in ExcelSheets.Rows) {
			MessageBox.Show(row.Item("TABLE_NAME"));
		}
	} catch (Exception ex) {
		throw new Exception(ex.Message);
	}
}
