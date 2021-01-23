	private void LogOnDialog_Closed(object sender, System.EventArgs e)
	{
      if(connection != null) //-> may have pressed cancel in the log on form
        formComboBox.DataSource = await connection.GetChoices();
	}
