    string responseString = @"{""hm_xytrict"":""HM Tricky District - oop"",""hmSD"":""HM Pool District""}";
    dynamic jsonResponse = JObject.Parse(responseString);
    foreach (var item in jsonResponse)
    {
        Console.WriteLine(item.Name);
        Console.WriteLine(item.Value);
    }
