    [XmlRoot(ElementName = "bonus")]
    public class Bonus
    {
        [XmlElement(ElementName = "int")]
        public List<string> Int { get; set; }
    }
    [XmlRoot(ElementName = "itemDefinition")]
    public class ItemDefinition
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "examine")]
        public string Examine { get; set; }
        [XmlElement(ElementName = "equipmentType")]
        public string EquipmentType { get; set; }
        [XmlElement(ElementName = "noted")]
        public string Noted { get; set; }
        [XmlElement(ElementName = "noteable")]
        public string Noteable { get; set; }
        [XmlElement(ElementName = "stackable")]
        public string Stackable { get; set; }
        [XmlElement(ElementName = "parentId")]
        public string ParentId { get; set; }
        [XmlElement(ElementName = "notedId")]
        public string NotedId { get; set; }
        [XmlElement(ElementName = "members")]
        public string Members { get; set; }
        [XmlElement(ElementName = "specialStorePrice")]
        public string SpecialStorePrice { get; set; }
        [XmlElement(ElementName = "generalStorePrice")]
        public string GeneralStorePrice { get; set; }
        [XmlElement(ElementName = "highAlcValue")]
        public string HighAlcValue { get; set; }
        [XmlElement(ElementName = "lowAlcValue")]
        public string LowAlcValue { get; set; }
        [XmlElement(ElementName = "bonus")]
        public Bonus Bonus { get; set; }
    }
    [XmlRoot(ElementName = "list")]
    public class List
    {
        [XmlElement(ElementName = "itemDefinition")]
        public List<ItemDefinition> ItemDefinition { get; set; }
    }
