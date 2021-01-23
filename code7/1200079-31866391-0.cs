    string ConvertIDToReg(string kairosID)
		{
			int id;
			if (!Int32.TryParse(kairosID, out id))
			{
				return "0";
			}
			return id.ToString("D5");
		}
    
