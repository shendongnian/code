    public ActionResult GetData()
    {
        foreach (var key in Request.Form.AllKeys)
        {
            //This will iterate through everything in your post data
            var value = Request.Form[key];
        }
    }
