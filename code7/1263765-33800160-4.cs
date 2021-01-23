    //TItemData is a name of this generic type. 
    //It could be T for example, just like variable name. 
    //These type names start from T by convention. 
    //This is not a new class or something like that.
    //where TItemData : ItemData is a constraint, 
    //that assumes that this type should be a subtype of ItemData
    public abstract class Item<TItemData> where TItemData : ItemData
    {
        protected TItemData Data;
    }
    
    //EquipmentData is a subtype of ItemData, so it fits here. 
    //No chances to write, for example, IntEquipment : Item<int> , 
    //because int does not derive from ItemData.
    public class Equipment : Item<EquipmentData>
    {
        //here Data will be of EquipmentData type, without any casting.
    }
