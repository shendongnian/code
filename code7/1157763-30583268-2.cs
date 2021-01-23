        if (hasDocuments)
        {
            // HTTP GET
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
    
            foreach (var d in returnValue.Result.SearchResults)
            {
                response = await client.GetAsync(d.Self + ".pdf");  
            };
        }
