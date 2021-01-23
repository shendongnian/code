        public Dictionary<string, string> FromJsonArray(string jsonArray)
        {
            return JsonConvert.DeserializeObject<string[]>(jsonArray)
                .ToDictionary(obj => obj.Split(',')[0], obj => obj.Split(',')[1]);
        }
        // ...
        var str = "[\"Ref No,0\",\"Date,0\",\"Amt,0\",\"Sender Name,0\",\"Sender Add,0\",\"Beneficiary Name,0\",\"Beneficiary Add,0\",\"Phone,0\",\"Secret Code,0\",\"Secret Ans,0\",\"Preferred Id,0\"]";
        
        foreach (var record in FromJsonArray(str))
		{
			Console.WriteLine("{0} => {1}", record.Key, record.Value);
		}
