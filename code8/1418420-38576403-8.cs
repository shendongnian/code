        dynamic arr = JArray.Parse(JSON); // response = json string above
        foreach (JObject token in arr)
        {
			dynamic value = token["value"];
            switch (token["value"].Type)
            {
                case JTokenType.String:
                    Console.WriteLine(value);
                    break;
                case JTokenType.Object:
                    Console.WriteLine(value.results.Last.value);
                    break;
            }
        }
