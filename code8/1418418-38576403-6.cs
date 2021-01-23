        dynamic arr = JArray.Parse(JSON); // response = json string above
        foreach (dynamic token in arr)
        {
            string tokenvalue = (string) token.value;
            JToken value = Regex.IsMatch(tokenvalue, "^\\{.*\\}$") 
                ? JToken.Parse(tokenvalue) 
                : token.value;
            switch (value.Type)
            {
                case JTokenType.String:
                    Console.WriteLine(value);
                    break;
                case JTokenType.Object:
                    Console.WriteLine(((dynamic)value).results.Last.value);
                    break;
            }
        }
