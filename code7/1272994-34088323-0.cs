        public static string SerializeObject(object value)
        {
            if (value.GetType() == typeof(string))
                return value.ToString();
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                DataContractSerializer serializer = new
                  DataContractSerializer(value.GetType());
                serializer.WriteObject(writer, value);
            }
            return stringWriter.ToString();
        }
