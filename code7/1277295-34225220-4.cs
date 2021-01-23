    public class inventoryRedo : MonoBehaviour
    { 
        public CSlot[] inventory;
        private int FindIndexOfNextFreeSlot()
        {
            int nIndex = -1;
            for (int i=0; i < inventory.Length; i++)
            {
                if (inventory[i].item == null)
                {
                    nIndex = i;
                }
            }
            return nIndex;
        }
        private void PutIntoInventory(int nIndex, GameObject gameObject)
        {
            inventory[nIndex].item == gameObject;
        }
    }
