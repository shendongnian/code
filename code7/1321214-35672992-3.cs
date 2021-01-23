    public IHttpActionResult GetHandleException(int num, string message = "")
    {
        switch (num)
        {
            case 12: return Redirect(message); //message string would be your url
            default: throw new Exception("base exception");
        }
    }
