	User dcUser = new User();
	int[] anSystemIDs = (int[])drUser["system_ids"];
	string strSystemIDs = "";
	dcUser.UserID = Convert.ToInt32(drUser["user_id"].ToString());
	for (int i = 0; i < anSystemIDs.Length ; i++)
	{
		strSystemIDs += anSystemIDs[i].ToString() + ", ";
	}
	dcUser.SystemIDs = strSystemIDs.Substring(0, strSystemIDs.Length - 2);
