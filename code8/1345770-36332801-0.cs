     Private Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = Repeater1.AlternatingItem OrElse e.Item.ItemType = Repeater1.Item Then
            Dim btn = TryCast(e.Item.FindControl("btnSave"), Button)
            If btn IsNot Nothing Then
                ' adding button event 
                btn.Click += New EventHandler(btn_Click)
            End If
        End If
    End Sub
    Private Sub btn_Click(sender As Object, e As EventArgs)
        'write your code 
    End Sub
