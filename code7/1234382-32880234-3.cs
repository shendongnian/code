    string[] inventoryData = File.ReadAllLines("Inventory.txt");
    List<string> inventoryDataList = inventoryData.ToList();
    if (inventoryDataList.RemoveAll(str => str == txtSearch.Text) > 0) // rewrite file if any item was found and deleted.
    {
        System.IO.File.WriteAllLines("Inventory.txt", inventoryDataList);
    }
