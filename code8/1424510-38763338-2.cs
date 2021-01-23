    public class UISettings
    {
        public UISettings()
        {
            ItemTable = new ItemTable();
            EffectiveItemPermissionTable = new EffectiveItemPermissionTable();
        }
        [XmlElement(Namespace = "Item")]
        public ItemTable ItemTable { get; set; }
        [XmlElement(Namespace = "Permissions")]
        public EffectiveItemPermissionTable EffectiveItemPermissionTable { get; set; }
    }
