    [Route("{id}")]
    [UserAuth(Roles =Directory.GroupUser)]
    [JsonException]
    [OutputCache(Duration = 600)]
    public ActionResult Select()
    {
      DoSelect();
    }
