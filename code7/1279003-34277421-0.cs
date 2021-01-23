    [ComVisible(true)]
    public class ScriptObject
    {
        public string GetJSon()
        {
            return JsonConvert.SerializeObject(new { a=1, b=2 });
        }
    }
