    string[] inventoryData = File.ReadAllLines("Inventory.txt");
    List<string> inventoryDataList = inventoryData.ToList();
    if (inventoryDataList.Remove(txtSearch.Text)) // rewrite file if item was found and deleted.
    {
        System.IO.File.Delete("Inventory.txt");
        System.IO.File.WriteAllLines("Inventory.txt", inventoryDataList);
    }
