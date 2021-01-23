    Public Class Form1
        Public Sub New()
            Me.InitializeComponent()
            Me.ClientSize = New Size(500, 300)
            Me.table = New DataTable()
            Me.table.Columns.Add("Text", GetType(String))
            Me.table.Columns.Add("Length", GetType(Integer))
            Me.table.Rows.Add("apple", 5)
            Me.table.Rows.Add("banana", 6)
            Me.table.Rows.Add("orange", 6)
            Me.textColumn = New DataGridViewTextBoxColumn() With {.DataPropertyName = "Text", .HeaderText = "Text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill}
            Me.lengthColumn = New DataGridViewTextBoxColumn() With {.DataPropertyName = "Length", .ReadOnly = True, .HeaderText = "Length (Computed)", .Width = 200, .MinimumWidth = 200}
            Me.grid = New DataGridView() With {.Dock = DockStyle.Fill, .AutoGenerateColumns = False, .DataSource = Me.table}
            Me.grid.Columns.AddRange({Me.textColumn, Me.lengthColumn})
            Me.Controls.Add(Me.grid)
        End Sub
        Private Sub HandleEcShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grid.EditingControlShowing
            If (Me.grid.CurrentCell.ColumnIndex = Me.textColumn.Index) Then
                Dim ec As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                Me.UnhookEc(ec) 'Important: Remove handles to avoid recursion.
                Me.HookEc(ec)
            End If
        End Sub
        Private Sub HandleEcTextChanged(sender As Object, e As EventArgs)
            Dim ec As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
            Dim cell As DataGridViewTextBoxCell = DirectCast(Me.grid.CurrentCell, DataGridViewTextBoxCell)
            Me.grid.Rows(cell.RowIndex).Cells(Me.lengthColumn.Index).Value = ec.Text.Length
        End Sub
        Private Sub HandleEcDisposed(sender As Object, e As EventArgs)
            Me.UnhookEc(TryCast(sender, DataGridViewTextBoxEditingControl)) 'Important: This will ensure removal of the hooked handles.
        End Sub
        Private Sub HookEc(ec As DataGridViewTextBoxEditingControl)
            If (Not ec Is Nothing) Then
                AddHandler ec.TextChanged, AddressOf Me.HandleEcTextChanged
                AddHandler ec.Disposed, AddressOf Me.HandleEcDisposed
            End If
        End Sub
        Private Sub UnhookEc(ec As DataGridViewTextBoxEditingControl)
            If (Not ec Is Nothing) Then
                RemoveHandler ec.TextChanged, AddressOf Me.HandleEcTextChanged
                RemoveHandler ec.Disposed, AddressOf Me.HandleEcDisposed
            End If
        End Sub
        Private WithEvents table As DataTable
        Private WithEvents grid As DataGridView
        Private WithEvents textColumn As DataGridViewTextBoxColumn
        Private WithEvents lengthColumn As DataGridViewTextBoxColumn
    End Class
