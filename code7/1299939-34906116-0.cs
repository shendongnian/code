    public class Item
    {
        public virtual void AddedToList(){}
    }    
    
    public class EquipItem
    {
        public override void AddedToList()
        {
            // behaviour specific to EquipItem
        }
    }
