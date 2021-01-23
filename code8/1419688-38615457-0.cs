    IEnumerable<PicklistData> results = deserializedPicklistData
      .Where(item => item.picklist_typ_key == gmwo.groupKey.ToString())
      .All(selectedItem => someFunction(selectedItem));
    
    :
    :
    
    someFunction(PicklistData myPick) {
    :
    }
