    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
		If e.Row.RowType = DataControlRowType.DataRow Then
			Dim ph As PlaceHolder = e.Row.FindControl("PlaceHolder1")
			If GridView1.DataKeys(e.Row.RowIndex).Value Mod 2 = 0 Then
				Dim tb As New TextBox()
				tb.Enabled = False
				tb.Text = CType(e.Row.DataItem, DataRowView)("user_logon")
				ph.Controls.Add(tb)
			Else
				Dim ddl As New DropDownList()
				ddl.DataSourceID = SqlDataSource2.ID
				ddl.DataTextField = "user_logon"
				ddl.DataValueField = "user_id"
				ph.Controls.Add(ddl)
				ddl.DataBind()
			End If
		End If
	End Sub
