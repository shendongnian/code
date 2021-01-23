	private string GetEnumListString<T>(IEnumerable list) where T : struct
	{
		string outValue = null;
		if (list != null)
		{
			outValue = "";
			// Parse the string list to get enum values into a list
			List<string> tempStatusList = new List<string>();
			foreach (object sts in list)
			{                    
				T enumValue;
				if (Enum.TryParse(sts.ToString(), out enumValue))
				{
					tempStatusList.Add((Convert.ToInt32(enumValue)).ToString());
				}
			}
			outValue = string.Join(",", tempStatusList);
		}
		return outValue;
	}
	private string GetPlanogramStatusListString()
	{
		return GetEnumListString<PogStoreData.PlanogramStatusCode>(this.POGSelectedStatusList);
	}
	private string GetMoveStatusListString()
	{
		return GetEnumListString<PogStoreData.POGMovedStatus>(this.POGMovedStatus);
	}
