    public clas FFIConfiguration : MarshalByRefObject, IUserConfig
    {
        public string UserName {get;set;}
        public DateTime ExecutionTime {get;set;}
        public Dictionary<String, String> ParametersDict { get; set; }
        public void SetToDictionary(string key, string value)
		{
            if (ParametersDict.ContainsKey(key))
				ParametersDict[key] = value;
			else
				ParametersDict.Add(key, value);
        }
    }
