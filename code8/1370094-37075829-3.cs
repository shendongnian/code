    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    if (obj != null && obj.pageResponses != null)
    {
        foreach (var pageResponse in obj.pageResponses)
        {
            if (pageResponse.scriptOutput == null)
                continue;
            foreach (var item in pageResponse.scriptOutput.items)
            {
                Console.WriteLine(item);
            }
        }
    }
