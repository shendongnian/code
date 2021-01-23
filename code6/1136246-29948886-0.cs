        Dictionary<string, object> deserialized = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        JArray messagesArray = deserialized["WaitForClientMessagesResult"] as JArray;
        foreach (JObject gatewayMessage in messagesArray.Children<JObject>())
        {
            string messageJson = gatewayMessage.ToString();
            WebClientMessageType messageType = GetMessageType(gatewayMessage);
            WaitForClientMessagesResult msg = null;
            switch (messageType)
            {
                case WebClientMessageType.KeepAlive:
                    msg = JsonConvert.DeserializeObject<KeepAliveMessage>(messageJson);
                    break;
                default:
                    break;
            }
        }
