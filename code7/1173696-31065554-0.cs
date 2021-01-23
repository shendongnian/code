    var numberToRemove = 3
    var result = Session["ID"]
        .Replace(numberToRemove.ToString(), string.Empty)
        .Replace(",,",",")
        .Trim(',');
    Session["ID"] = result;
