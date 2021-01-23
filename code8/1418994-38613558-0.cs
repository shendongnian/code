     Public Sub MyGridView_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim checkCell As String = DirectCast(e.Row.FindControl("Label11"), Label).Text
            If checkCell = 0 Then
                e.Row.Cells(11).BackColor = Drawing.Color.Green
                e.Row.Cells(11).ForeColor = Drawing.Color.White
            ElseIf checkCell > 0 And checkCell < 11 Then
                e.Row.Cells(11).BackColor = Drawing.Color.Yellow
            ElseIf checkCell > 10 Then
                e.Row.Cells(11).BackColor = Drawing.Color.Red
                e.Row.Cells(11).ForeColor = Drawing.Color.White
            End If
        End If
    End Sub
