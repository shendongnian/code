    JObject jsonObject = JObject.Parse(courselist);
    foreach (JProperty prop in jsonObject.Properties())
    {
        Debug.WriteLine(prop.Name);  // chapter1
        Debug.WriteLine(prop.Value["name"].ToString());  // Successful Sales
        // Get page numbers and URLs
        int count = 0;
        foreach (JProperty pageProp in ((JObject)prop.Value).Properties())
        {
            if (pageProp.Name != "name")
            {
                Debug.WriteLine(pageProp.Name + ": " + 
                                pageProp.Value["url"].ToString());
                count++;
            }
        }
        Debug.WriteLine(count + " total pages.");
    }
