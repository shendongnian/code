    List<List<string>> thisListOfArray = new List<List<string>>();
    List<string> thisArrayA = new List<string>();
    List<string> gMaintenanceB = new List<string>();
    thisArrayA.Add("ItemA1");
    thisArrayA.Add("ItemA2");
    thisArrayA.Add("ItemA3");
    gMaintenanceB.Add("ItemB1");
    gMaintenanceB.Add("ItemB2");
    gMaintenanceB.Add("ItemB3");
    thisListOfArray.Add(thisArrayA);
    thisListOfArray.Add(gMaintenanceB);
    foreach (var item in thisListOfArray)
    {
         foreach (var itm in item)
         {
             MessageBox.Show(itm);                    
         }
    }
