    List<string> categories = new List<string>();
  
    WebRequest request = HttpWebRequest.Create(myurl);
    WebResponse response = request.GetResponse();
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    {
      string json = reader.ReadToEnd();
      JArray data = JArray.Parse(json);
      foreach (JObject entry in data.Children<JObject>())
      {
        foreach (JProperty p in entry.Properties())
        {
          if (p.Name.Equals("sub_category_en"))
          {
            string value = (string)p.Value;
            categories.Add(value);
          }
        }
      }
    }
    
