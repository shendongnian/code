    void Main()
    {
    	Weapon<Foo> weapon = new Weapon<Foo>();
    	IItem<ItemData> other = weapon;
    }
    
    public interface IItem<out T> {}
    public interface IItemData {}
    
    public class Foo : WeaponData {}
  
    public class Data : ScriptableObject {}
    public class ItemData : Data, IItemData {}
    public class WeaponData : ItemData {}
    
    public abstract class Item<T> : Visual<T>, IItem<T> where T : IItemData {}
    public class Weapon<T> : Item<T> where T : WeaponData {}
    
    public class ScriptableObject {}
    public class Visual<T> {}
