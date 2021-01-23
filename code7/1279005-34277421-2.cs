    [ComVisible(true)] // <== Needed
    public class ScriptObject
    {
        public string GetJSon()
        {
            return JsonConvert.SerializeObject(new { a=1, b=2 });
            //not recommended way
            //return "{\"a\":1,\"b\":2}";
        }
    }
