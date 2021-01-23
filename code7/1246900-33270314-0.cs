                DataContractJsonSerializer serializer = new DataContractJsonSerializer(GenericObject.GetType());
                MemoryStream ms = new MemoryStream();
                serializer.WriteObject(ms, GenericObject);
                string json = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return json;
            
