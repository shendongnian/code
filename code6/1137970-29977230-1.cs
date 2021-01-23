    @if (User.Identity.IsAuthenticated && User.IsInRole("ITS-Dept"))
    {
      // add the nav element here for "ITS-Dept" users
    }
    @if (User.Identity.IsAuthenticated && Session["isSignedUp"] == "true")
    {
      // add nav element for this Session val
    }
    @if (User.Identity.IsAuthenticated && Session["canSignUp"] == "true")
    {
      // add nav element for this Session val
    }
    @if (User.Identity.IsAuthenticated && Session["canWeighIn"] == "true")
    {
      // add nav element for this Session val
    }
