        public static string ConvertToXml(object obj)
        {
            StringWriter result = new StringWriter(new StringBuilder());
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(result, obj);
                return result.ToString();
            }
            catch (Exception ex)
            {
                return result.ToString();
            }
        }
