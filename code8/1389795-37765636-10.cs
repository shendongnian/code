    private List<string> GetCheckBoxListSelections(string listName, CheckBoxList cbl)
            {
                List<string> SelectedCheckBoxes = new List<string>();
                var selectedCheckBoxItems = from key in Request.Form.AllKeys
                                            where key.Contains(cbl.ID)
                                            select new { Key = key };
    
    
                foreach (var item in selectedCheckBoxItems)
                {
                    SelectedCheckBoxes.Add(item.Key);
                }
                return SelectedCheckBoxes;
            }
