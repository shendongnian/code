     IDictionary<string, string> setting = new Dictionary<string, string>(); 
    
         try
            {
              // Test if the content can be parsed as XElement before contract deserialize
             XElement xNode = XElement.Parse(settingValue.ToString());
             if (xNode != null)
             {
               setting = (IDictionary<string, string>)XmlUtil.DataContractDeserialize(settingValue.ToString(), setting.GetType());
             }
          }
         catch (XmlException)
         {
          
         }
