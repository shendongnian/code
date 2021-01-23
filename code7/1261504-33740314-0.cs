    [HttpPost]
    public ActionResult Index(int? id)
    {
        Stream req = Request.InputStream;
        req.Seek(0, System.IO.SeekOrigin.Begin);
        string json = new StreamReader(req).ReadToEnd();
    
        InputClass input = null;
        try
        {
            // assuming JSON.net/Newtonsoft library from http://json.codeplex.com/
            input = JsonConvert.DeserializeObject<InputClass>(json)
        }
    
        catch (Exception ex)
        {
            // Try and handle malformed POST body
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    
        //do stuff
    
    }
