    Private dgvDV As DataView
    Private dgvBS As BindingSource
    ' config:
    dgvDV = New DataView(dgvDT)
    dgvBS = New BindingSource()
    dgvBS.DataMember = "myDT"
    dgvBS.DataSource = dgvDT
    dgv2.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
    dgv2.Columns(1).SortMode = DataGridViewColumnSortMode.Programmatic
    dgv2.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic
