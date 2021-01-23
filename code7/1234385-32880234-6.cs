    string[] inventoryData = File.ReadAllLines("Inventory.txt");
    List<string> inventoryDataList = inventoryData.ToList();
    if (inventoryDataList.Remove(txtSearch.Text)) // rewrite file if one item was found and deleted.
    {
        System.IO.File.WriteAllLines("Inventory.txt", inventoryDataList.ToArray());
    }
