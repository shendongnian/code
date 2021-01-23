    string var1 =
    @"Start Date: 
    2015 - 1 - 1
    End Date: 
     2017 - 1 - 1
    Warranty Type: 
     XXX
    Status: 
     Active
    Serial Number / IMEI: 
     XXXXXXXX
    Description:
    This product has a three year limited warranty and is entitled to parts, labor and on-site repair service. Service is available Monday - Friday, except holidays, with a next business day response objective. Many parts can also be delivered to you using the Customer Replaceable Unit (CRU)method.";
    // Remove all spaces and newlines
    var1 = var1.Replace(" ", "").Replace("\r\n", "");
    // our regex pattern now that there ar eno spaces or new lines
    var regex = new Regex(@"StartDate:(.*)EndDate:(.*)W.*Status:(.*)\/");                   
    //assign them
    string strStartDate = regex.Match(var1).Groups[1].ToString();
    string strEndDate = regex.Match(var1).Groups[2].ToString();
    string Status = regex.Match(var1).Groups[3].ToString().Substring(0, 6);
    //convert to DateTime from our string versions
    DateTime StartDate = DateTime.Parse(strStartDate);
    DateTime EndDate = DateTime.Parse(strEndDate);
   
