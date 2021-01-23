    List<As_SenderCountry> list = new List<As_SenderCountry>();
    // some sort of loop
    As_SenderCountry asc = new As_SenderCountry();
    ...
    list.Add(asc);
    // end loop
    GetCountryInfo_Resp.As_SenderCountry = list.ToArray();
