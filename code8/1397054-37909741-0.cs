    public static implicit operator MyThirdClass(string s)
    {
      // when serializing indented =>
      // return JsonConvert.DeserializeObject<B3>(s, new JsonSerializerSettings() { Formatting = Formatting.Indented});
      // otherwise
      return JsonConvert.DeserializeObject<B3>(s);
    }
