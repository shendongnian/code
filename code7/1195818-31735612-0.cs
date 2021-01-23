    List<string> values = new List<string>();
                values.Add("not flat");
                values.Add("not covered");
                values.Add("accepted");
                values.Add("accepted");
                values.Add("not flat");
                values.Add("not flat");
                values.Add("not covered");
                values.Add("not flat");
    
     List<string> distinctValues = values.Distinct().ToList();
