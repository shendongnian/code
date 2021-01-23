        public string GetPrevious(string value)
        {
            var list = new[]
            {
                new {SPName = "F12"},
                new {SPName = "T16"},
                new {SPName = "K15"},
                new {SPName = "F10"},
                new {SPName = "K14"},
                new {SPName = "T9"},
                new {SPName = "T7"}
            };
            return
                list.Where(
                    l => l.SPName.ToCharArray().First() == value.ToCharArray().First() &&
                        GetValue(l.SPName) < GetValue(value)).OrderByDescending(l => GetValue(l.SPName)).First().SPName;
        }
        public int GetValue(string value)
        {
            return int.Parse(value.Substring(1, value.Length - 1));
        }
