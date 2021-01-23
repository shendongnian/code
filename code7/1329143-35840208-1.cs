    string ApplyChange(string originalJson, string path, string jsonToAdd)
    {
        var root = JObject.Parse(originalJson);
        var node = root.SelectToken(path);
        switch (node.Type)
        {
            case JTokenType.Object:
            {
                var objectToMerge = JObject.Parse("{" + jsonToAdd + "}");
                ((JObject)node).Merge(objectToMerge);
                break;
            }
            case JTokenType.Array:
            {
                var objectToMerge = new JArray(JToken.Parse(jsonToAdd));
                ((JArray)node).Merge(objectToMerge);
                break;
            }
            default:
                throw new NotSupportedException();
        }
        return root.ToString();
    }
