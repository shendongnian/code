    Private Sub ReplaceByteColumns(table As DataTable)
        Dim byteColumns As New Dictionary(Of DataColumn, DataColumn)
        For Each column As DataColumn In table.Columns
            If column.DataType = GetType(Byte()) Then
                Dim byteColumn As New DataColumn
                byteColumn.DataType = GetType(String)
                byteColumns.Add(column, byteColumn)
            End If
        Next
        For Each column As DataColumn In byteColumns.Keys
            Dim byteColumn As DataColumn = byteColumns(column)
            table.Columns.Add(byteColumn)
            For Each row As DataRow In table.Rows
                row.Item(byteColumn) = BitConverter.ToString(CType(row.Item(column), Byte()))
            Next
            byteColumn.SetOrdinal(column.Ordinal)
            byteColumn.ReadOnly = True
            table.Columns.Remove(column)
            byteColumn.ColumnName = column.ColumnName
        Next
    End Sub
