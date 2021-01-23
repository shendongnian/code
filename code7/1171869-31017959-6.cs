    public class MenusConfigurationSection : ConfigurationSection
    {
       [ConfigurationProperty("Menus", IsDefaultCollection = false)]
       [ConfigurationCollection(typeof(MenuCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
       public MenuCollection Menus
       {
          get
          {
             return (MenuCollection)base["Menus"];
          }
       }
    }
