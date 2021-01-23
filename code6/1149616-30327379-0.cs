    var xml = "<root><Message type='sms'><Details locale='en' message-type='User.ResetPassword' /><Context><Parameter name='Time' value=' 16:03:31' /><Parameter name='pswr' value='00' /><Parameter name='Date' value='18/12/2014' /></Context><Receiver>+923328749199</Receiver></Message></root>";
    var document = XDocument.Parse(xml);
    
    var messages = document.Root.Elements();
    foreach (var message in messages)
    {
    	var context = message.Element("Context");
    	var parameters = context.Elements("Parameter");
    	foreach (var parameter in parameters)
    	{
    		var name = parameter.Attribute("name").Value;
    		var value = parameter.Attribute("value").Value;
    		
    		Console.WriteLine ("Parameter {0} with value of {1}", name, value);
    	}
        
        Console.WriteLine ("Receiver {0}", message.Element("Receiver").Value);
    }
