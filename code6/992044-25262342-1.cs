    GlobalResponseFilters.Add((req, res, obj) => {
        // Handle void responses
        if(obj == null && res.StatusCode == 200)
        {
            res.StatusCode = (int)HttpStatusCode.NoContent;
            res.StatusDescription = "No Content";
        }
    });
