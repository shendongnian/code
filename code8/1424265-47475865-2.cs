    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "TENANT")]
    [HttpGet("issue-type-selection"), Produces("application/json")]
    public async Task<IActionResult> IssueTypeSelection()
    {
        try
        {
            return new ObjectResult(await _item.IssueTypeSelection(User));
        }
        catch (ExceptionNotFound)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new
            {
                error = "invalid_grant",
                error_description = "Item Not Found"
            });
        }
    }
