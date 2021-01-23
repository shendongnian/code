    var str = "AD 123 (+45) AS 6.7(+8%)";
    var doubles = new List<double>();
    foreach (var item in Regex.Matches(str, @"(\d|\.)+"))
    {
        doubles.Add(double.Parse(item.ToString()));
    }
    //doubles = [123, 45, 6.7, 8] 
