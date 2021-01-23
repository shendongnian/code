    class MyDto
    {
        public string Name { get; set; }
        public string Other { get; set; }
        public string Remap { get; set; }
    }
    class MyBusinessObject
    {
        [JsonIgnore]
        public string Other { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Remap")]
        public string RemmapedField { get; set; }
    }
    public T DeepCopy<T>(object o)
    {
        string json=JsonConvert.SerializeObject(o);
        T newO=JsonConvert.DeserializeObject<T>(json);
        return newO;
    }
