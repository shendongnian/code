    [Route("account/confirm")]
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string userId, string code) {
      if (userId == null || code == null) {
        return Content(JsonConvert.SerializeObject( new { result = "false", message = "data is incorrect" }), "application/json");
      }
      var user = await _userManager.FindByIdAsync(userId);
      if (user == null) {
        return Content(JsonConvert.SerializeObject(new { result = "false", message = "user not found" }), "application/json");
      }
      //var decodedCode = HttpUtility.UrlDecode(code);
      //var result = await _userManager.ConfirmEmailAsync(user, decodedCode);
      var result = await _userManager.ConfirmEmailAsync(user, code);
      if (result.Succeeded)
        return Content(JsonConvert.SerializeObject(new { result = "true", message = "ок", token = code }), "application/json");
      else
        return Content(JsonConvert.SerializeObject(new { result = "false", message = "confirm error" }), "application/json");
    }
