    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
	  If e.Row.RowType = DataControlRowType.DataRow Then
		Dim gv2 As GridView = DirectCast(e.Row.FindControl("GridView2"), GridView)
		Dim sds As SqlDataSource = DirectCast(e.Row.FindControl("SqlDataSource2"), SqlDataSource)
		sds.SelectParameters("user_id").DefaultValue = GridView1.DataKeys(e.Row.RowIndex).Value
		gv2.DataBind()
	  End If
	End Sub
