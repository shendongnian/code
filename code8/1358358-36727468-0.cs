        Private Sub gvExpertRateHistory_PreRender(sender As Object, e As System.EventArgs) Handles gvExpertRateHistory.PreRender
			Dim this As GridView = sender
			Dim InnerTable As Table = If(this.HasControls(), this.Controls(0), Nothing)
			If this.HeaderRow IsNot Nothing AndAlso InnerTable IsNot Nothing Then
				Dim hr As GridViewRow
				hr = New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
				hr.Cells.Add(NewCell(1, String.Empty, this, , HorizontalAlign.Left))
				hr.Cells.Add(NewCell(2, "Requested On", this, , HorizontalAlign.Left))
				hr.Cells.Add(NewCell(4, "Review Rates", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(6, "Court Rates", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(6, "Deposition Rates", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(4, "IME Rates", this, "WhiteBorderLB"))
				InnerTable.Rows.AddAt(0, hr)
				hr = New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
				hr.Cells.Add(NewCell(1, "Expert", this, , HorizontalAlign.Left))
				hr.Cells.Add(NewCell(2, "Requested By", this, , HorizontalAlign.Left))
				hr.Cells.Add(NewCell(2, "Hourly", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Flat", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Hourly", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Daily", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Half-Day", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Hourly", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Daily", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Half-Day", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Hourly", this, "WhiteBorderLB"))
				hr.Cells.Add(NewCell(2, "Flat", this, "WhiteBorderLB"))
				InnerTable.Rows.AddAt(1, hr)
			End If
		End Sub
