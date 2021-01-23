    var query = xml.Elements("LootProfile")
        .Select(item => new LootProfile()
        {
            //...
            staticDrop = item.Elements("staticDrop")
                .Select((Item, Index) => new { Item, Index })
                        .ToDictionary(
                            x => x.Index,
                            x => new Tuple<int, float>(
                                int.Parse(x.Item.Attribute("idPattern").Value),
                                float.Parse(x.Item.Value))),
            //..
        });
