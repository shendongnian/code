    var quests = new List<Quest>();
	if (this.OpenConnection() == true)
	{
		MySqlCommand cmd = new MySqlCommand(query, connection);
		MySqlDataReader dataReader = cmd.ExecuteReader();
		while (dataReader.Read())
		{
			var quest = new Quest
			{
				QuestName = (string) dataReader["QuestName"],
				QuestId = (string) dataReader["QuestId"],
				GiverName = (string) dataReader["GiverName"],
				GiverId = (string) dataReader["GiverId"],
				MoveToX = (string) dataReader["MoveToX"],
				MoveToY = (string) dataReader["MoveToY"],
				MoveToZ = (string) dataReader["MoveToZ"]
			};
			quests.Add(quest);
					
		}
		dataReader.Close();
		this.CloseConnection();
		return quests;
    }
