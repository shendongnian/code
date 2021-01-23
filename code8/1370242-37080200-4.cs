    using System.Resources;
    List<string> _paths = new List<string> { ConfigurationManager.AppSettings["SpanPath"], ConfigurationManager.AppSettings["FrenPath"], ConfigurationManager.AppSettings["RusPath"] };
    Hashtable oHt = new Hashtable();
    // Read the keys and store in a hash table
    using (ResXResourceReader oReader = new ResXResourceReader(_paths.ElementAt(0)))
    {
         IDictionaryEnumerator oResource = oReader.GetEnumerator();
         while (oResource.MoveNext())
                 oHt.Add(oResource.Key,oResource.Value);
    }
    //Add the new keys to the hash table
    oHt["Key1"] = "String1";
    oHt["Key2"] = "String2";
    //Re-generate the new  resx from the hash table
    using (ResXResourceWriter oWriter = new ResXResourceWriter(_paths.ElementAt(0)))
    {
          foreach (string key in oHt.Keys)
               oWriter.AddResource(key.ToString(), oHt[key].ToString());
          oWriter.Generate();
    }
