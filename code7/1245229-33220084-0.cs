    void Main()
    {
    	var csvList = new List<PersonInfoCSVModel>();
    	var yourPersonObject; //already filled with the data you want
    	
    	yourPersonObject.AddressList.ForEach(address =>
    	{
    		csvList.Add(new PersonInfoCSVModel()
    		{
    			Name = yourPersonObject.Name,
    			Phone = yourPersonObject.Phone,
    			City = address.City,
    			Street = address.Street
    		});
    	});
    	
    	yourCSVContext.Write(csvList, "yourFile.csv");
    }
    
    class PersonInfoCSVModel
    {
    	[CsvColumn(Name = "Name", FieldIndex = 1)]	
       	public string Name{get;set;}
    	
    	[CsvColumn(Name = "Phone", FieldIndex = 2)]	
       	public string Phone {get;set;}
    	
    	[CsvColumn(Name = "City", FieldIndex = 3)]	
      	public string City { get; set;}
    	
    	[CsvColumn(Name = "Street", FieldIndex = 2)]	
       	public string Street {get;set;}
    }
