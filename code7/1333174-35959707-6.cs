	var source = 
		from r in grdViewLastHearingDates.Rows.OfType<GridViewRow>()
		select new UpdateCaseConveyanceRec
		{
			CaseHearingID = Convert.ToInt32(r.Cells[0].Text),
			ConvenienceRemarks = (r.FindControl("txtBoxConvenienceRemarks") as TextBox).Text;
			IsConveyed = (r.FindControl("chkBoxIsConveyed") as CheckBox).Checked
		};
	
	bool updated = UpdateCasesIsConveyed(source);
