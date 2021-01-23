    public JsonResult GetRepositoryDeatil(long id)
    {
        var client = new GitHubClient(new ProductHeaderValue("demo"));
        var tokenAuth = new Credentials("xxxxxxx"); // NOTE: not real token
        client.Credentials = tokenAuth;
        var content = client.Repository.Content.GetAllContents(id).Result;
        List<RepositoryContent> objRepositoryContentList = content.ToList();
        return Json(objRepositoryContentList, JsonRequestBehavior.AllowGet);
    }
