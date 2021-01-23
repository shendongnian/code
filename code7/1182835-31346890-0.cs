        public static List<T> JsonToListOfEnvelopes<T>(string data, string searchString, Func<string, T> creator)
        {
            List<T> ListOfEnvelopes = new List<T>();
            if (!string.IsNullOrEmpty(data))
            {
                JObject productsJson = JObject.Parse(data);
                JToken jtkProduct;
                jtkProduct = productsJson[searchString];
                if (jtkProduct != null)
                    if (jtkProduct.HasValues)
                    {
                        int childrenCount = productsJson[searchString].Count();
                        for (int x = 0; x < childrenCount; x++)
                            ListOfEnvelopes.Add(creator(productsJson[searchString][x]));
                    }
            }
            return ListOfEnvelopes;
        }
