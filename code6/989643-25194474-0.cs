    JObject jsonObject = JObject.Parse(courselist);
    foreach (JProperty prop in jsonObject.Properties())
    {
        Debug.WriteLine(prop.Name);  // chapter1
        Debug.WriteLine(prop.Value["name"].ToString());  // Successful Sales
    }
