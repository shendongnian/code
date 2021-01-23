            // Load the JSON into an intermediate JObject
            var rootObj = JObject.Parse(json);
            // Restructure the JObject hierarchy
            foreach (var obj in rootObj.SelectTokens("Children[*]").OfType<JObject>())
            {
                var metadata = obj.SelectToken("MetaData[0]"); // Get the first entry in the "MetaData" array.
                if (metadata != null)
                {
                    // Remove the entire "Metadata" property.
                    metadata.Parent.RemoveFromLowestPossibleParent();
                    // Set the name and value
                    var name = metadata.SelectToken("Name");
                    var id = metadata.SelectToken("Data.Text");
                    if (name != null && id != null)
                        obj[(string)name] = (string)id;
                    // Move all other atomic values.
                    foreach (var value in metadata.SelectTokens("..*").OfType<JValue>().Where(v => v != id && v != name).ToList())
                        value.MoveTo(obj);
                }
            }
            Debug.WriteLine(rootObj);
            // Now deserialize the preprocessed JObject to the final class
            var root = rootObj.ToObject<RootObject>();
