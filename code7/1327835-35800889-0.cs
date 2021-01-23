    string var1 =
    @"Start Date: 
        2015-1-1
        EndDate:
        2017-1-1
        Status:
        Active";
    // Remove all spaces and newlines
    var1 = var1.Replace(" ", "").Replace("\r\n", "");
    // our regex pattern now that there are no spaces or new lines
    var regex = new Regex("StartDate:(.*)EndDate:(.*)Status:(.*)");           
    //Output each match
    foreach (var group in regex.Match(var1).Groups)
    {
      Console.WriteLine(group);
    }
    //or assign them directly
    string strStartDate = regex.Match(var1).Groups[1].ToString();
    string strEndDate = regex.Match(var1).Groups[2].ToString();
    string Status = regex.Match(var1).Groups[3].ToString();
    //convert to DateTime from our string versions
    DateTime StartDate = DateTime.Parse(strStartDate);
    DateTime EndDate = DateTime.Parse(strEndDate);
