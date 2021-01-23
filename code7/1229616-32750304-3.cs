	Private Sub rptSP1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptSP1.ItemDataBound
		'Perform this check because you only need the actual data items.
		If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
			Dim intIdFromSp1 As Integer = CType(e.Item.DataItem, TheClassOfItemsInYourArrayList).IdField
			Dim rptSP2 As Repeater = CType(e.Item.FindControl("rptSP2"), Repeater)
			Dim rptSP3 As Repeater = CType(e.Item.FindControl("rptSP3"), Repeater)
			
			'Code that gets the data from the other SPs would be in a Function called GetDataTableFromSP2.
			rptSP2.DataSource = GetDataTableFromSP2(intIdFromSp1)
			rptSP2.DataBind()
			
			rptSP3.DataSource = GetDataTableFromSP3(intIdFromSp1)
			rptSP3.DataBind()
			
		End If
		
	End Sub
	
