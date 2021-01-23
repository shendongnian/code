    public class MyType
    {
        public List<abcModel> A { get; set; }
    }
    JsonConvert.DeserializeObject<MyType>(json);
