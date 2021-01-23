    void Main()
    {
        var resObj = JsonConvert.DeserializeObject<JObject>(jsonString);
        GetKeyValuePairs((JObject)resObj["fmi"]).Dump();
    }
    private string GetKeyValuePairs(JObject resObj)
    {
        string sDict = string.Empty;
        string fmitxt = string.Empty;
        string fmitxt2 = string.Empty;
        foreach (var pair in resObj)
        {
          sDict += "<tr><td> " + pair.Key + "</td>";
          if (pair.Value is JObject)
            sDict += "<td>" + GetKeyValuePairs((JObject)pair.Value) + "</td></tr>";
          else
            sDict += "<td>" + pair.Value.ToString() + "</td></tr>";
        }
        return sDict;
    }
