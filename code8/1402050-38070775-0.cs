    public class ClassWithList
    {
        public List<object> list { get; set; }
    }
    var o = JsonConvert.DeserializeObject<ClassWithList>(json);
    if (o.list != null && o.list.Count > 0)
    { }
