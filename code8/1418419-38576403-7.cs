        dynamic arr = JArray.Parse(JSON); // response = json string above
        foreach (dynamic token in arr)
        {
            JTokenType type = ((JToken)token.value).Type;
            switch (type)
            {
                case JTokenType.String:
                    Console.WriteLine(token.value);
                    break;
                case JTokenType.Object:
                    Console.WriteLine(token.value.results.Last.value);
                    break;
            }
        }
    
