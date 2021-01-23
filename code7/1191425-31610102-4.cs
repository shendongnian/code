    [HttpPost]
    public async Task<ActionResult> Create(User source)
    {
        if (Request.Cookies["AdminCookie"] == null)
            return RedirectToRoute("Home");
    
        if (ModelState.IsValid)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49474/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    var response = await client.PostAsJsonAsync("api/user", source); //debug here to ensure you are getting a response
                    var serializer = new JavaScriptSerializer();
                    var dataObject = serializer.Deserialize<SomeResponse>(response);
    
                    if (dataObject.Success)
                    {
                        return Responder("Success", true);
                    }
                }
                return Responder();
            }
            catch(Exception ex)
            {
                ReportError(ex, "CREATE");
                return Responder();
            }
        }
    }
    private object Responder(string message = "Did not succeed", bool succeeded = false)
    {
        return new
             {
                 Message = message,
                 IsOK = succeeded
             };
    }
    public IHttpActionResult Post([FromBody]User Source)
    {
        try
        {
            User u = new User();
            u.EmailAddress = Source.EmailAddress;
            u.FirstName = Source.FirstName;
            u.LastName = Source.LastName;
            u.Password = Hashing.CreatePassword(Source.Password);
            u.RoleId = Source.RoleId;
            u.Role = db.Roles.Single(x => x.Id == u.RoleId);
    
            db.Users.Add(u);
            db.SaveChanges();
    
            return new SomeResponse().Success = true;
        }
        catch (Exception ex)
        {
            return ReportError(ex, "POST USER");
        }
    }
    
    public class SomeResponse
    {
        public bool Success { get; set; }
    }
