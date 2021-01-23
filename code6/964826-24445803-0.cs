    List<object> GetGroupNames(int groupRowVisibleIndex){
      List<object> result = new List<string>();
      int childCount = ASPxGridView1.GetChildRowCount(groupRowIndex);
    
      for(int i = 0; i < childCount; i ++)  
        result.Add(ASPxGridView1.GetChildRowValues(groupRowVisibleIndex, i, "CarName"));
    }
