    using UnityEngine;
    using System.Collections.Generic;
    
    public class Item {
    
      public List<string> validInvTypes = new List<string>();
      
      //...
    }
    
    public class Gem : Item {
      
      //...
    }
    
    public class Ruby : Gem {
    
      public Ruby()
      {
        validInvTypes.Add("Ruby");
        validInvTypes.Add("Gem");
        validInvTypes.Add("Item");
      }
    
      //...
    }
    
    public abstract class SlotHandler<ItemType> : MonoBehaviour, IDropHandler where ItemType : Item {
    
      //...
    
      public void OnDrop(PointerEventData eventData)
      {
        //...
    
        //string currentInvSlot
        //Item droppedItem
    
        if (droppedItem.validInvTypes.Contains(currentInvSlot))
          // Swap the items...
      }
    }
