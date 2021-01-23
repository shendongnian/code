    // **snip**
    using (var response = request.GetResponse())
    {
        using (var sw = new StreamReader(response.GetResponseStream()))
        {
            var result = sw.ReadToEnd();
        }
    }
    // **snip**
