    public class InheritedDict : Dictionary<string, string>
    {
        void IDictionary<string, string>.Add(string key, string value)
        {
            base.Add(key, value);
        }
    }
    Dictionary<string, string> d = new InheritedDict<string, string>();
    var d2 = d as IDictionary<string, string>;
    d2.Add("foo", "bar"); // Ok
