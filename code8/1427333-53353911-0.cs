    Public Class Form1
      Private WithEvents DGV As New DataGridView
      Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV.SetBounds(20, 50, 400, 200)
        Controls.Add(DGV)
        DGV.Columns.Add("Qty", "Qty")
        DGV.Columns.Add("Price", "Price")
        DGV.Columns.Add("Total", "Total")
        DGV.Columns("Total").ReadOnly = True
        DGV.RowCount = 5
      End Sub
    
      Private Sub DGV_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellValueChanged
        If e.ColumnIndex = DGV.Columns("Qty").Index Or e.ColumnIndex = DGV.Columns("Price").Index Then
          DGV("Total", e.RowIndex).Value = CInt(DGV("Qty", e.RowIndex).Value) * CDbl(DGV("Price", e.RowIndex).Value)
        End If
      End Sub
    End Class
