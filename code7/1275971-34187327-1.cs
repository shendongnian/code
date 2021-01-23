    public List<Models.EmployeeInfo> GetEmployeeInfo(SPListItemCollection splic)
    {
       var listEmployeeInfo = new List<Models.EmployeeInfo>();
       foreach (SPListItem splicItem in splic)
       {               
          listEmployeeInfo.Add(SPListItemToEmployeeInfoMapper.Map(splicItem));
       }
       return listEmployeeInfo;
    }
