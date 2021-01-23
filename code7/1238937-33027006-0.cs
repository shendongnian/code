    ''' <summary>
    ''' Row count including only standard rows, i.e. without new row.
    ''' </summary>
    <Extension>
    <DebuggerStepThrough>
    Function StandardRowCountᛎ(dataGridView As DataGridView) As Integer
        Return dataGridView.Rows.Count - If(dataGridView.AllowUserToAddRows, 1, 0)
    End Function
    ''' <summary>
    ''' The same as <see cref="DataGridView.NewRowindex"/> but reliable also after cancelled new record.
    ''' </summary>
    <Extension>
    <DebuggerStepThrough>
    Function NewRowIndexᛎ(dataGridView As DataGridView) As Integer
        Return If(dataGridView.AllowUserToAddRows, dataGridView.Rows.Count - 1, -1)
    End Function
    ''' <summary>
    ''' The same as <see cref="DataGridViewRow.IsNewRow"/> but reliable also after cancelled new record.
    ''' </summary>
    <Extension>
    <DebuggerStepThrough>
    Function IsNewRowᛎ(row As DataGridViewRow) As Boolean
        Return row.DataGridView.AllowUserToAddRows AndAlso row.Index = row.DataGridView.Rows.Count - 1
    End Function
