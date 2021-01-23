    public static IEnumerable<Record> ReadFile(string input)
	{
        // Alter these as appropriate
        const int RECORDTYPELENGTH = 2;
		const int COMPANYNAMELENGTH = 41;
		const int ITEMNUMBERLENGTH = 8;
		const int DESCRIPTIONLENGTH = 48;
		int index = 0;
		string companyName = null;
		string itemNumber = null;
		while (index < input.Length)
		{
			string recordType = input.Substring(index, RECORDTYPELENGTH);
			index += RECORDTYPELENGTH;
			if (recordType == "00")
			{
				companyName = input.Substring(index, COMPANYNAMELENGTH).Trim();
				index += COMPANYNAMELENGTH;
			}
			else if (recordType == "01")
			{
				itemNumber = input.Substring(index, ITEMNUMBERLENGTH).Trim();
				index += ITEMNUMBERLENGTH;
			}
			else if (recordType == "02")
			{
				string description = input.Substring(index, DESCRIPTIONLENGTH).Trim();
				index += DESCRIPTIONLENGTH;
				yield return new Record
				{
					CompanyName = companyName,
					ItemNumber = itemNumber,
					Description = description
				};
			}
		}
	}
