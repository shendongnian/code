    public class XmlResultDeserializer : XmlDeserializer
    {
        public override T Deserialize<T>(IRestResponse response)
        {
            if (!typeof(T).IsGenericType || typeof(T).GetGenericTypeDefinition() != typeof(Result<>))
                return base.Deserialize<T>(response);
            // Determine whether the response contains an error or normal data.
            var doc = XDocument.Parse(response.Content);
            var result = Activator.CreateInstance<T>();
            if (doc.Root != null && doc.Root.Name == "Error")
            {
                // It's an error
                var error = base.Deserialize<Error>(response);
                var errorProperty = result.GetType().GetProperty("Error");
                errorProperty.SetValue(result, error);
            }
            else
            {
                // It's just normal data
                var innerType = typeof(T).GetGenericArguments()[0];
                var deserializeMethod = typeof(XmlDeserializer)
                    .GetMethod("Deserialize", new[] { typeof(IRestResponse) })
                    .MakeGenericMethod(innerType);
                var data = deserializeMethod.Invoke(this, new object[] { response });
                var dataProperty = result.GetType().GetProperty("Data");
                dataProperty.SetValue(result, data);
            }
            return result;
        }
    }
