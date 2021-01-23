    private void Update(string key, object value)
    {
      if (Memory._Map.ContainsKey(key))
      {
        Memory._Map[key] = value;
      }
      else if (key.ToLower() == "result")
      {
        Memory._Results[Memory._Results.Count - 1] = value;
      }
      else if (key.ToLower() == "storage")
      {
        Memory._Storage[Memory._Storage.Count - 1] = value;
      }
      else if (key.ToLower().Contains("result"))
      {
        int n = Convert.ToInt32(key.ToLower().Split(new string[] { "result" }, StringSplitOptions.None)[1]);
        Memory._Results[n] = value;
      }
      else if (key.ToLower().Contains("storage"))
      {
        int n = Convert.ToInt32(key.ToLower().Split(new string[] { "storage" }, StringSplitOptions.None)[1]);
        Memory._Storage[n] = value;
      }
      else
      {
        throw new ArgumentException("Failed to compute valid mapping", nameof(key));
      }
    }
