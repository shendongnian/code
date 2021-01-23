    [HttpPost]
    [Route("addrole")]
    public async Task<ActionResult> AddRole(string description)
    {
      IdentityRole role = new IdentityRole();
      role.Name = description;
      var result = await RoleManager.CreateAsync(role);
      if (result.Succeeded)
      {
        return Json(role.Id);
      } else {
        return Json(null);
      }
    }
