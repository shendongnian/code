    [Route("{id}")]
    [OutputCache(Duration = 600)]
    [UserAuth(Roles =Directory.GroupUser)]
    [JsonException]
    public ActionResult Select()
    {
    DoSelect();
    }
