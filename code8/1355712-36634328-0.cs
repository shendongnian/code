    [HttpGet]
    public ActionResult SearchUser()
    {           
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> SearchUser(UserSearchRequest userSearchRequest)
    {
        HttpClient client = new HttpClient();
        CreateLogInRequest userObject = null;
        string baseUrl = "http://test/api/users";
        if (userSearchRequest.FirstName != null && userSearchRequest.LastName)
        {
            var response = await client.GetAsync(string.Format("{0}{1}/{2}/{3}", baseUrl, "/users", userSearchRequest.FirstName, userSearchRequest.LastName));
            if (response.IsSuccessStatusCode)
            {
                userObject = new JavaScriptSerializer().DeserializeObject<CreateLogInRequest>(response.Content.ReadAsStringAsync().Result);
            }
        }
        if (userObject != null)
        {
            return RedirectToAction("Create", userObject);
        }
        return View("Create", null);
    }
    [HttpPost]
    public ActionResult Create(CreateLogInRequest createLogInRequest)
    {
        return View();
    }
