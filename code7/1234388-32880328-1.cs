    List<string> InventoryData = File.ReadAllLines("Inventory.txt").ToList();            
    for (int i = 0; i < InventoryData.Count; i++)
    {
        if (InventoryData[i] == txtSearch.Text)
        {
            InventoryData.RemoveAt(i);
            break;            
        }
    }
    System.IO.File.WriteAllLines("Inventory.txt", InventoryData.AsEnumerable());
