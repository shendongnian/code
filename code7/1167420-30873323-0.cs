    Type type = myObj.GetType();
    List<string> info = new List<String>();
    info.Add("Object type that has thrown an error is: " + type.ToString() + Environment.NewLine);
    foreach (var prop in type.GetProperties())
    {
    	if (prop.CanRead)
    	{
    		info.Add("Name: " + prop.Name + " , Value: " + prop.GetValue(myObj) + Environment.NewLine);
    	}
    }
    Logger.log(string.Join("", info));
