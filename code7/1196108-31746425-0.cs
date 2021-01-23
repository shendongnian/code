    class Program
    {
        static void Main(string[] args)
        {
            var json =
               "{'a': 1, 'b': {'c': {}, k: [], z: [1, 3]},'d': {'e': 1,'f': {'g': {}}}}";
            var parsed = (JContainer)JsonConvert.DeserializeObject(json);
            var nodesToDelete = new List<JToken>();
            do
            {
                nodesToDelete.Clear();
                ClearEmpty(parsed, nodesToDelete);
                foreach (var token in nodesToDelete)
                {
                    token.Remove();
                }
            } while (nodesToDelete.Count > 0);
            
        }
        private static void ClearEmpty(JContainer container, List<JToken> nodesToDelete)
        {
            if (container == null) return;
            foreach (var child in container.Children())
            {
                var cont = child as JContainer;
                if (child.Type == JTokenType.Property ||
                    child.Type == JTokenType.Object ||
                    child.Type == JTokenType.Array)
                {
                    if (child.HasValues)
                    {
                        ClearEmpty(cont, nodesToDelete);
                    }
                    else
                    {
                        nodesToDelete.Add(child.Parent);
                    }
                }
            }
        }
    }
