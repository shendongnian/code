    Protected Sub ShoesRepeater_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles ShoesRepeater.ItemCommand
      Select Case e.CommandName  'This is the clicked button's CommandName
        Case "b1"
          'Do stuff for Button1
          'e.CommandArgument is the clicked button's CommandArgument
          'e.Item.FindControl("lblPrice") allows you to access other controls in this same Repeater item as the button that was clicked.
        Case "b2"
          'Do stuff for Button2
      End Select
      'There's a decent chance you'll want to rebind the grid when you're done.
    End Sub
