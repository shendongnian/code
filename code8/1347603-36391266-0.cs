    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowState = DataControlRowState.Normal And e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpGridView As GridView = e.Row.FindControl("GridView2")
            If Not tmpGridView Is Nothing Then
                tmpGridView.DataSource = DaoUser.findAll
                tmpGridView.DataBind()
            End If
        End If
    End Sub
