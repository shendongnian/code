    var results = phoneNo
        .AsParallel()
        .Select(number => new { 
             number, 
             result = webserviceClass123.callWebserviceMethod(number)
        })
        .AsOrdered()
        .ToList()
    var builder = new StringBuilder();
    foreach (int i = 0; i < results.Count; i++)
    {
        builder.AppendFormat("{0} {1} {2}<br/>",
            i, result[i].number, results[i].result);
    }
    Literal1.Text = builder.ToString();
