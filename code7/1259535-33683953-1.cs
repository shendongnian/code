    [NotMapped]
    public DataTable TableOfInformation
    {
    	get
    	{
    		if (string.IsNullOrWhiteSpace(TableOfInformationJson))
    		{
    			return new DataTable();
    		}
    		return TableOfInformationJson.JsonDeserialize<DataTable>();
    	}
    	set { TableOfInformationJson = value.ToJson(); }
    }
	
