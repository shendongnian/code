     public Message SerializeReply(
                MessageVersion messageVersion,
                object[] parameters,
                object result)
            {
                // In this sample we defined our operations as OneWay, therefore, this method
                // will not get invoked.
    
    
    
                var clientAcceptType = WebOperationContext.Current.IncomingRequest.Accept;
    
                Type type = result.GetType();
    
                var genericResponseType = typeof(Response<>);
                var specificResponseType = genericResponseType.MakeGenericType(result.GetType());
                var response = Activator.CreateInstance(specificResponseType, result);
    
                Message message;
                WebBodyFormatMessageProperty webBodyFormatMessageProperty;
    
    
                if (clientAcceptType == "application/json")
                {
                    message = Message.CreateMessage(messageVersion, "", response, new DataContractJsonSerializer(specificResponseType));
                    webBodyFormatMessageProperty = new WebBodyFormatMessageProperty(WebContentFormat.Json);
    
                }
                else
                {
                    message = Message.CreateMessage(messageVersion, "", response, new DataContractSerializer(specificResponseType));
                    webBodyFormatMessageProperty = new WebBodyFormatMessageProperty(WebContentFormat.Xml);
    
                }
    
                var responseMessageProperty = new HttpResponseMessageProperty
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
    
                message.Properties.Add(HttpResponseMessageProperty.Name, responseMessageProperty);
    
                message.Properties.Add(WebBodyFormatMessageProperty.Name, webBodyFormatMessageProperty); 
                return message;
            }
