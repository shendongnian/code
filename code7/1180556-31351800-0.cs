	protected void accFuncPerm_ItemCommand(object sender, CommandEventArgs e)
	{
		AccordionContentPanel acpContent;
		AccordionPane aPane = accFuncPerm.Panes[accFuncPerm.SelectedIndex];
		Control[] controls;
		//Find accPagPerm
		controls = new Control[aPane.Controls.Count];
		aPane.Controls.CopyTo(controls, 0);
		acpContent = (AccordionContentPanel)controls.Single(c => c.FindControl("accPagPerm") != null);
		Accordion accPagPerm = (Accordion)acpContent.FindControl("accPagPerm");
		//Find hfID
		aPane = accPagPerm.Panes[int.Parse(txtAcc.Text)];
		controls = new Control[aPane.Controls.Count];
		aPane.Controls.CopyTo(controls, 0);
		acpContent = (AccordionContentPanel)controls.Single(c => c.FindControl("hfID") != null);
		HiddenField hf = (HiddenField)acpContent.FindControl("hfID");
	}
