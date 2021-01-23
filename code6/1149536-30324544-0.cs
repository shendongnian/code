    var xml = XElement.Parse(GetXmlToProcess());
	var messages = xml.Elements("Message").Select(x=> 
						  {
						  	  return GetMessageFromXml(x);
						  });
    //method to parse
	public Message GetMessageFromXml( XElement elem)
	{
			var msg  = new Message();
			var type = elem.Attributes("type").FirstOrDefault();
			msg.Type =type != null? type.Value : null;
			var detail =elem.Elements("Details");
			if (detail != null)
			{
				var locale = detail.Attributes("locale").FirstOrDefault();
				var messageType = detail.Attributes("message-type").FirstOrDefault();
				msg.Details = new Detail()
								{
									Locale=locale != null? locale.Value: null,
									MessageType= messageType != null? messageType.Value: null
								};
			}
			
			var reciever =elem.Elements("Receiver").FirstOrDefault();
			if (reciever != null)
			{
				msg.Receiver = reciever.Value;
			}
			var context = elem.Elements("Context");
			if (context != null)
			{
				msg.Context = new Context();
				msg.Context.Parameters.AddRange(context.Elements("Parameter").Select(x=>
				{
					var parameter = new Parameter();
					var name = x.Attributes("name").FirstOrDefault();
					var value = x.Attributes("value").FirstOrDefault();
					parameter.Name = name!= null? name.Value:null;
					parameter.Value = value!=null? value.Value:null;
					return parameter;
				}).ToList());
			}
			return msg;
	}
