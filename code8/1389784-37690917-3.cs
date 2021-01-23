    var selectedCheckBoxItems = from key in Request.Form.AllKeys
                            where key.Contains(cbl.ID)
                            select new {Value = Request.Form.Get(key), Key = key};
    string[] stringParse = new string[] {listName.Replace(" ", "") + '$'};
    foreach (var item in selectedCheckBoxItems)
    {
    	var val = item.Value;
    	var key = item.Key;
    	var idxArray = key.Split(stringParse, StringSplitOptions.None);
    	var idxString = idxArray[idxArray.Length - 1];
    	int idxInt;
    	if (Int32.TryParse(idxString, out idxInt))
    	{
    		cbl.Items[idxInt].Selected = true;
    	}
    }
