    Protected Sub GrdVacation_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdVacation.RowDataBound
    
        If (e.Row.RowType = DataControlRowType.DataRow) Then
        //// Dim NM = CType(e.Row.Cells(0).Controls(7), ImageButton)
        Dim NM = CType(e.Row.Cells(7).Controls(0), ImageButton)
    
    
         if(true) Then
            NM.ImageURL="somepath"
         End If
   
