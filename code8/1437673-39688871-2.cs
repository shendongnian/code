    // Get the contents of the first user data
    List<string> CombinedDatas = UserData1.GetFields();
    // Combine in the contents of the second user data
    // AddRange actually changes the first list (CombinedDatas)
    CombinedDatas.AddRange(UserData2.GetFields());
    // If you wanted to save out the combined data in a new xml file
    UserDataContainer FinalData = new UserDataContainer();
    FinalData.SetFields(CombinedDatas);
    
    FinalData.Save(FinalDataPath);
