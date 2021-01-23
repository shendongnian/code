    var myObj = objDataSet.Tables[0].AsEnumerable()
    .Where(roww => Convert.ToInt64(item.Substring(1, item.Length - 1)) == roww.Field<Int64>(0))
    .FirstOrDefault();
    if (myObj != null)
    {
        //reuse myObj here
        if (myObj...)
        {
            ExistingPhones.Add(item.Substring(1, item.Length - 1), true);
        }
        else
        {
            UpdatePhones.Add(item.Substring(1, item.Length - 1), true);
        }
    }
    else
    {
        ActivePhones.Add(item.Substring(1, item.Length - 1), true);
    }
