    public ActionResult PostData()
    {
        string parms;
        using (var sr = new System.IO.StreamReader(Request.InputStream))
        {
             parms = sr.ReadToEnd();
        }
        // Submit parms to third-party api.
        return new EmptyResult();
    }
