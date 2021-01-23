    var staffNames = sql.Staff_Time_TBLs.Select(item => item.Staff_Name).Distinct().ToList();
    
    for (int i = 0; i < staffNames.Count; i++)
    {
         MessageBox.Show(staffNames[i].ToString());
    }
