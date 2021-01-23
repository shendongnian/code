    Public Class Form1
      Private WithEvents DGV As New DataGridView
      Private DT As New DataTable
      Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV.SetBounds(20, 50, 400, 200)
        Controls.Add(DGV)
        DT.Columns.Add("Qty", GetType(Int32))
        DT.Columns.Add("Price", GetType(Double))
        DT.Columns.Add("Total", GetType(Double))
        DT.Columns("Total").Expression = "Qty * Price"
        DGV.DataSource = DT
      End Sub
    End Class
