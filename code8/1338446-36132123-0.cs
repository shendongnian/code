    If(User.Identity.IsAuthenticated)
    {
        If(User.Identity.IsInRole=="admin")
        {
            return view("Secret");
        }
        else
        {
                return view("NotAllowed")
        }
    }
    else
    {
        return View("NeedAuth");
    }
