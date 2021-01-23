    [TestMethod]
    public void Test()
    {
        var template = "A:<<Default>>;B:<<Default>>;C:<<Default>>;D:<<Default>>;E:<<Default>>";
        Assert.AreEqual(Item.Process("A:aaa;E:eee", template),
            "A:aaa;B:<<Default>>;C:<<Default>>;D:<<Default>>;E:eee");
        Assert.AreEqual(Item.Process("D:ddd", template),
            "A:<<Default>>;B:<<Default>>;C:<<Default>>;D:ddd;E:<<Default>>");
        Assert.AreEqual(Item.Process("B:bbb;E:eee", template),
            "A:<<Default>>;B:bbb;C:<<Default>>;D:<<Default>>;E:eee");
    }
    public class Item
    {
        public static char InnerSeperator = ':';
        public static char OuterSeperator = ';';
        public static string DefaultValue = "<<Default>>";
        public Item(string asString)
        {
            var strings = asString.Split(InnerSeperator).ToList();
            Key = strings[0];
            Value = strings.Count > 1 ? strings[1] : DefaultValue;
        }
        public string Key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return string.Format("{0}{1}{2}", Key, InnerSeperator, Value);
        }
        public static string ToStringJoined(IEnumerable<Item> items)
        {
            return string.Join(OuterSeperator.ToString(), items.Select(i => i.ToString()));
        }
        public static IEnumerable<Item> FromJoinedString(string joined)
        {
            return joined.Split(OuterSeperator)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => new Item(x));
        }
        public static string Process(string values, string template)
        {
            var templateItems = FromJoinedString(template);
            var valueItems = FromJoinedString(values);
            var resultItems = templateItems.Select(t => valueItems.FirstOrDefault(x => x.Key == t.Key) ?? t);
            return ToStringJoined(resultItems);
        }
    }
