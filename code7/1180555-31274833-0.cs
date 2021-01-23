    public class Item : MonoBehaviour
    {
        [System.Serializable]
        public ItemModel Model;
    }
 
    public class ItemModel
    {
        public string Name;
        public int Id;
    }
