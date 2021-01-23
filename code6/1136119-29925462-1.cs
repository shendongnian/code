     private static void GetKeys(JObject obj, List<string> keys)
        {
            var result = obj.Descendants()
                .Where(f => f is JProperty) //.Where(f => f is JProperty) 
                .Select(f => f as JProperty)// and .Select(f => f as JProperty) can be replaced with .OfType<JProperty>()
                .Select(f=>f.Path)
                .Where(f=> !keys.Contains(f));
            keys.AddRange(result);
        }
        static void Main(string[] args)
        {         
            IEnumerable<string> txts = @"{'id':'123', 'name':'hello, world',     'department':[{'name':'dept1', 'deptID':'123'}]}
    {'id':'456324', 'department':[{'name':'dept2', 'deptID':'456'}]}".Split("\r\n".ToArray(),StringSplitOptions.RemoveEmptyEntries);
            List<string> keys = new List<string>();
            foreach (var item in txts)
            {
                var obj = JObject.Parse(item);
                GetKeys(obj, keys);
            }
}
