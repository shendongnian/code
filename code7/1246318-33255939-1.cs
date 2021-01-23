    'CLONE COLUMNS ONLY'
    Dim dgv As New DataGridView
    For Each dgvCol As DataGridViewColumn In CtrlDataGridView1.Columns
        dgv.Columns.Add(New DataGridViewColumn(dgvCol.CellTemplate))
    Next
    'COPY SELECTED / UNSELECTED ROWS AS PER YOUR REQUIREMENT'
    For Each dr As DataGridViewRow In CtrlDataGridView1.Rows
        If dr.Selected Then
        'OR If Not dr.Selected Then'
            dgv.Rows.Add(dr.Clone)
        End If
    Next
