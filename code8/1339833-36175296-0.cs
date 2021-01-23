    var valToRemove = "L1"; //provided by user
    var remarks = dSet.Tables[0].Rows[i]["REMARKS"];
    var splittedRemarks = remarks.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
    splittedRemarks.Remove(valToRemove);
    dSet.Tables[0].Rows[i]["REMARKS"] = splittedRemarks.Join(",");
