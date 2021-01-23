	protected void btnVot_Click(object sender, EventArgs e)
	{
		try
		{
			//Save Data
			sqlCon = DBConnection.GetConnection(string.Empty);
			if (sqlCon == null)
				return;
			
			foreach (RepeaterItem item in rpAnswers.Items)
			{
				if (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem)
					continue;
				
				VotingAnswers AnswerObj = (VotingAnswers )item.DataItem;
				HtmlInputRadioButton rbMyRadio = (HtmlInputRadioButton)item.FindControl("rbMyRadio");
				if (rbMyRadio == null || !rbMyRadio.Checked)
					continue;
				
				VotAns.AnswerCount = +1;
				VotAns.AnswerRatio = (VotAns.AnswerCount * 100) / 100;
				if (VotAnswerDAO.Update(sqlCon, VotAns))
				{
					divQuestion.Visible = false;
					divVoting.Visible = true;
				}
			}
			VotingAnswers AnswerObj = (VotingAnswers)item.DataItem;        
		}
		catch (Exception ex)
		{
			//Do some exception handling here
		}
		finally
		{
			if (sqlCon != null)
			{
				sqlCon.Close();
				sqlCon.Dispose();
			}
		}
	}
