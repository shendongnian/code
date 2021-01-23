    if (Request.Files.Count > 0)
    {
        for (int i = 0; i < Request.Files.Count; i++)
        {
            var file = Request.Files[i];
            ...
        }
    }
