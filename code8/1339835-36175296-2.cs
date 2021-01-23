    var valToRemove = "L1"; //provided by user
    var remarks = dSet.Tables[0].Rows[i]["REMARKS"];
    var splittedRemarks = new List<string>(remarks.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries));
    splittedRemarks.Remove(valToRemove); //If you need to remove all the L1 values use `RemoveAll` method instead
    dSet.Tables[0].Rows[i]["REMARKS"] = splittedRemarks.Join(",");
