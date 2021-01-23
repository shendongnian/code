    var responseCode = Response.StatusCode;
    try
    {
        // Exception was called
    }
    catch (BusinessLayerException1)
    {
        responseCode = 201
    }
    catch (BusinessLayerException2)
    {
        responseCode = 202
    }
    Response.StatusCode = responseCode;
