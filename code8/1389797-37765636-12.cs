    List<int> SelectedCheckBoxes = new List<int>();
    var selectedCheckBoxItems = from key in Request.Form.AllKeys
                                        where key.Contains(cblAnimalType.ID)
                                        select Request.Form.Get(key);
    foreach (var item in selectedCheckBoxItems)
    {
      SelectedCheckBoxes.Add(int.Parse(item.ToString()));
    }
