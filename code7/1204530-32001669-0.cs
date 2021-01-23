    //update these lines in updateHeatmapURL mthod
    // dlg.File name is not accessable because updateHeatmapURL method is static
    // use instance to access dlg or remove static, if you remove static then you need to remove it from other two methods as well
    var userId = getUserID();
    selectGaze.Parameters.Add("@userID", MySqlDbType.Int64).Value = userId;
    selectGaze.Parameters.Add("@gazeID", MySqlDbType.Int64).Value = getgazeID(userId);
