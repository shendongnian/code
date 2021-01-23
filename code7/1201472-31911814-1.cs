    public async Task<ActionResult> Login(Models.LoginFormModel model, string returnUrl = "")
    {
        try
        {
            if (ModelState.IsValid)
            {
                /* ... more code ... */
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
        // If we got this far, something failed; redisplay form
        return View(model);
    }
