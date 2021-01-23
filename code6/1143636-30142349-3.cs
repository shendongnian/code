            var jArray = JArray.FromObject(obj);    // obj must serialized to an array; throw an exception otherwise.
            var jObj = new JObject(jArray           // Allocate new outer JSON object
                .Cast<JObject>()                    // All array element must be json objects
                .SelectMany(o => o.Properties())
                .GroupBy(p => p.Name, p => p.Value) // Group all array element properties by name
                .Select(g => new JProperty(g.Key, g))); // Add an array-valued property to the new outer object.
            var json = jObj.ToString();
            Debug.WriteLine(json);
