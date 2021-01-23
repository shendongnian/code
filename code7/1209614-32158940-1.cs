	DataTable characterDataTable = character.getAllCharacters();
	foreach(DataRow row in characterDataTable.Rows)
	{
	  Button button = new Button();
	  button.Text = row["character"].ToString();
	  button.ID = row["character"].ToString() + "_btn";
      button.CommandName = row["id"].ToString();
	  button.Click += character_btn_Click;
	}
