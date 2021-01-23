    var query = xml.Elements("LootProfile")
        .Select(item => new LootProfile()
        {
            //...
            dynamicType =
                item.Elements()
                    .Where(x => x.Name.LocalName.StartsWith("dynamicType"))
                    .ToDictionary(
                        x => (ObjectType)Enum.Parse(
                            typeof(ObjectType),
                            x.Name.LocalName.Substring("dynamicType".Length)),
                        x => float.Parse(x.Value))
            //...
        });
