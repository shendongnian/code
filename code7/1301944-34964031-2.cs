    var query = xml.Elements("LootProfile")
        .Select(item => new LootProfile()
        {
            name = (string) item.Attribute("name"),
            dynamicDropNumber = (int) item.Element("dynamicDropNumber"),
            dynamicDrop =
                item.Elements("dynamicDrop")
                    .Select((Item, Index) => new {Item, Index})
                    .ToDictionary(x => x.Index, x => float.Parse(x.Item.Value))
            //other element....
        });
  
    var result = query.ToList();
