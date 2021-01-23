    var valToRemove = "L1"; //provided by user
    var remarks = dSet.Tables[0].Rows[i]["REMARKS"];
    var splittedRemarks = new List<string>(remarks.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries));
    splittedRemarks.Remove(valToRemove);
    dSet.Tables[0].Rows[i]["REMARKS"] = splittedRemarks.Join(",");
