    Object[] tempItems = Resources.LoadAll("Inventory/Weapons",typeof(GameObject));
    foreach (Object i in tempItems)
    {
        GameObject it = (GameObject)i;
        Debug.Log(it);
        itemList.Add(it);
        Debug.Log(itemList.Count);
    }
    foreach (Object i in tempItems)
    {
        Resources.UnloadAsset(i);
    }
