    [Serializable]
    public class MyItem
    {
        public int Id;
        public string Name;
        public bool isItem;
    }
    
    [Serializable]
    public class Items
    {
        public MyItem[] items;
    }
    
    //elsewhere
    public void SaveTemplate()
    {
        List<MyItem> itemList = new List<MyItem>();
        itemList.Add(new MyItem { Id = 1, Name = "Wood", isItem = true });
        itemList.Add(new MyItem { Id = 2, Name = "Stone", isItem = true });
    
        Items itemArray = new Items();
        itemArray.items = itemList.ToArray();
    
        string json = JsonUtility.ToJson(itemArray, true);
        YourFunctionToSaveTheTextSomewhere(json);
        
    }
