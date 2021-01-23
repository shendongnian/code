    public abstract class InventoryItem
    // or interface
    {
      public abstract string Name { get; }
      public int Count { get; set; }
    }
    public class InventoryGold : InventoryItem 
    {
      public string Name { get { return "Gold" } }
    }
    public abstract class InventoryWeapon : InventoryItem { }
    public class OgreSlayingKnife : InventoryWeapon
    {
      public string Name { get { return "Ogre Slaying Knife"; } }
      public int VersusOgres { get { return +9; } }
    }
    public UpdateCount<Item>(this ICollection<Item> instance, 
      int absoluteCount)
    {
      var item = instance.OfType<Item>().FirstOrDefault();
      if (item == null && absoluteCount > 0)
      {
        item = default(Item);
        item.Count = absoluteCount;
        instance.add(item);
      }
      else
      {
        if (absoluteCount > 0)
          item.Count = absoluteCount;
        else
          instance.Remove(item);
      }
    }
    // Probably should be a Hashset
    var inventory = new List<InventoryItem>();
    inventory.UpdateCount<InventoryGold>(10);
    inventory.UpdateCount<OgreSlayingKnife(1)
