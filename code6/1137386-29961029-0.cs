    string d = "۱۳۹۴/۰۲/۲۰";
    int year = Int32.Parse(string.Join("", 
        d.Split('/')[0].Select(c => char.GetNumericValue(c)))); // 1394
    int month = Int32.Parse(string.Join("", 
        d.Split('/')[1].Select(c => char.GetNumericValue(c)))); // 2
    int day = Int32.Parse(string.Join("", 
        d.Split('/')[2].Select(c => char.GetNumericValue(c)))); // 20
