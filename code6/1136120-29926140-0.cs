        public static HashSet<string> GetTokensFromJson(IEnumerable<string> txts)
        {
            var distinctKeys = new HashSet<string>(txts.Select(t => JObject.Parse(t)).Where(o => o != null).SelectMany(o => o.Descendants().OfType<JProperty>()).Select(p => p.Name));
            return distinctKeys;
        }
