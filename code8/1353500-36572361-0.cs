    [AllowAnonymous]
    [Route("register")]
    public async Task<IHttpActionResult> Register(IdentityUser user)
    {
        await _userStore.CreateAsync(user);
        return Ok();
    }
