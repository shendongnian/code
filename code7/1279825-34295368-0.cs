    sqlCmd2.Parameters.Clear(); // Add This line
    sqlCmd2.Parameters.Add("@EventId", SqlDbType.Int).Value = 2;
    sqlCmd2.Parameters.Add("@FormId", SqlDbType.Int).Value = 2;
    sqlCmd2.Parameters.Add("@ColumnName", SqlDbType.NVarChar).Value = lbl.Text;
    sqlCmd2.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = lbl.Text;
    sqlCmd2.Parameters.Add("@Visible", SqlDbType.Bit).Value = 1;
    sqlCmd2.Parameters.Add("@ColumnOrder", SqlDbType.NVarChar).Value = i;
    sqlCmd2.ExecuteNonQuery(); // Add This line
