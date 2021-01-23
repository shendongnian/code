    [WebMethod]
    public static object GetSubTaskStories(string id)
    {
        // Do some stuff.
        try
        {
            var storiesObj = new { success = true, stories = stories };
            return storiesObj;
        }
        catch (Exception ex)
        {
            var error = new { success = false };
            return error;
        }
    }
