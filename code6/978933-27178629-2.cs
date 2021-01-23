      public IEnumerable<JProperty> DoCompare(string expectedJSON, string actualJSON)
        {
            // convert JSON to object
            JObject xptJson = JObject.Parse(expectedJSON);
            JObject actualJson = JObject.Parse(actualJSON);
            // read properties
            var xptProps = xptJson.Properties().ToList();
            var actProps = actualJson.Properties().ToList();
            // find missing properties
            var missingProps = xptProps.Where(expected => actProps.Where(actual => actual.Name == expected.Name).Count() == 0);
            return missingProps;
        }
