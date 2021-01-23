        private static void Reffing(this IDictionary<string, object> current, Action<object> exchange,IDictionary<string, object> refdic)
        {
            object value;
            if(current.TryGetValue("$ref", out value))
            {
                if(!refdic.TryGetValue((string) value, out value))
                    throw new Exception("ref not found ");
                if (exchange != null)
                    exchange(value);
                return;
            }
            if (current.TryGetValue("$id", out value))
            {
                refdic[(string) value] = current;
            }
            foreach (var kvp in current.ToList())
            {
                if (kvp.Key.StartsWith("$"))
                    continue;
                var expandoObject = kvp.Value as ExpandoObject;
                if(expandoObject != null)
                    Reffing(expandoObject,o => current[kvp.Key]=o,refdic);
                var list = kvp.Value as IList<object>;
                if (list == null) continue;
                for (var i = 0; i < list.Count; i++)
                {
                    var lEO = list[i] as ExpandoObject;
                    if(lEO!=null)
                        Reffing(lEO,o => list[i]=o,refdic);
                }
            }
        }
