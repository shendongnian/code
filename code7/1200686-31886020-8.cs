    public class Foo
    {
        public string Name { get; set; }
        public Bar Bar { get; set; }
    }
    public class Bar
    {
        public string Data { get; set; }
        public string MoreData { get; set; }
    }
    var fooSerializer = new XmlSerializer(typeof (Foo));
    fooSerializer.UnknownElement += (sender, e) =>
    {
        var foo = (Foo) e.ObjectBeingDeserialized;
        if(foo.Bar == null)
            foo.Bar = new Bar();
        var propName = e.Element.Name.Substring(4);
        typeof(Bar).GetProperty(propName).SetValue(foo.Bar, e.Element.InnerText);
    };
    var fooInstance = fooSerializer.Deserialize(...);
