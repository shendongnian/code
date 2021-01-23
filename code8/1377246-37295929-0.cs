    try
    {
        // ...
    }
    catch (HttpException ex) when (ex.StatusCode == 404)
    {
        // ...
    }
    catch (HttpException ex) when (ex.StatusCode == 500)
    {
        // ...
    }
