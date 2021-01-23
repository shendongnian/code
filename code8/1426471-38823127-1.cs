    public T ConvertFromXml<T>(string yourXml, params object[] activationData)
    	where T : new() //if your type has default constructor
    {
    	var resultType = typeof(T);
    	//if your type has not default constructor
    	var result = (T)Activator.CreateInstance(typeof(T), activationData);
    	//if it has default constructor
    	var result = new T();
    	
    	//create an instance of xml reader
    	var xmlDocument = new XmlDocument();
    	xmlDocument.LoadXml(yourXml);
    
    	//expecting that your xml response will always have the same structure
    	if (xmlDocument.SelectSingleNode("RESPONSE/SINGLE") != null)
    	{
    		foreach(XmlNode node in xmlDocument.SelectNodes("RESPONSE/SINGLE/KEY"))
    		{
    			var prop = resultType.GetProperty(node.Attributes["name"].Value);
    			if (prop != null)
    			{
    				var value = prop.SelectSingleNode("Value").Value;
    				//if value does not exist - check if null value can be assigned
    				if (value == null && (!prop.PropertyType.IsValueType || (Nullable.GetUnderlyingType(prop.PropertyType) != null)))
    				{
    					prop.SetValue(result, value); //explicitly setting the required value
    				} 
    				else if (value != null)
    				{
    					//we receiving the string, so for number parameters we should parse it
    					if (IsNumberType(prop.PropertyType))
    					{
    						prop.SetValue(result, double.Parse(value));
    					}
    					else
    					{
    						prop.SetValue(result, value); //will throw an exception if property type is not a string
    					}
    					
    					//need some additional work for DateTime, TimeSpan, arrays and other
    				}
    				
    			}
    			else 
    			{
    				//remove next line if you do not need a validation for property presence
    				throw new ArgumentException("Could not find the required property " + node.Attributes["name"].Value);
    			}
    		}
    	}
    	else 
    	{
    		throw new ArgumentException("Xml has invalid structure");
    	}
    	
    	return result;
    }
    
    private bool IsNumberType(Type t)
    {
    	var numberTypes = new[] {
    		typeof(byte), typeof(short), typeof(int), typeof(long),
    		typeof(float), typeof(double), typeof(decimal),
    		typeof(byte?), typeof(short?), typeof(int?), typeof(long?),
    		typeof(float?), typeof(double?), typeof(decimal?)
    	};
    	
    	return numberTypes.Contains(t);
    }
