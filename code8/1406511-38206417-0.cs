    Partial Public Class MyDataSet
        Partial Class MyDataTable
    
            Private Sub MyDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
                If (e.Column.ColumnName = Me.MyColumn.ColumnName) Then
                    'Add user code here - Get and update ChildRow
    
                End If
    
            End Sub
    
        End Class    
    End Class
