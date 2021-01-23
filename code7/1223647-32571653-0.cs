    class NListBuilder
    {
        Dictionary<int, List<string>> tags = new Dictionary<int, List<string>>();
        public NListBuilder()
        {
            tags.Add(1, new List<string>() { "A", "B", "C" });
            tags.Add(2, new List<string>() { "+", "-", "*" });
            tags.Add(3, new List<string>() { "1", "2", "3" });
        }
        public List<string> AllCombos
        {
            get
            {
                return GetCombos(tags);
            }
        }
        List<string> GetCombos(IEnumerable<KeyValuePair<int, List<string>>> remainingTags)
        {
            if (remainingTags.Count() == 1)
            {
                return remainingTags.First().Value;
            }
            else
            {
                var current = remainingTags.First();
                List<string> outputs = new List<string>();
                List<string> combos = GetCombos(remainingTags.Where(tag => tag.Key != current.Key));
                foreach (var tagPart in current.Value)
                {
                    foreach (var combo in combos)
                    {
                        outputs.Add(tagPart + combo);
                    }
                }
                return outputs;
            }
        }
    }
