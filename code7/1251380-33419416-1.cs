    public ActionResult Custom(RoleEnum userRole)
    {
        var view = GetViewByRole(userRole);
        // where GetViewByRole takes the enum and 
        // returns a string with the name of the partial
        return Partial(view, viewModel);
    }
