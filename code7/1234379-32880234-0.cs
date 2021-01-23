    string[] inventoryData = File.ReadAllLines("Inventory.txt");
    List<string> filteredInventory = inventoryData.ToList();
    filteredInventory.Remove(txtSearch.Text);
    System.IO.File.Delete("Inventory.txt");
    System.IO.File.WriteAllLines("Inventory.txt", filteredInventory);
