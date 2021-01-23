    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject item = JObject.Load(reader);
        switch (item["type"].Value<string>())
        {
            case "Armor":
                var armorItem = new ArmorItem();
                serializer.Populate(item.CreateReader(), armorItem);
                return armorItem;
            default:
                var defaultItem = new Item();
                serializer.Populate(item.CreateReader(), defaultItem);
                return defaultItem;
        }
    }
