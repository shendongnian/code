    public ActionResult Index()
    {
        var FavouriteColour = "";
        var ClaimsIdentity = User.Identity as ClaimsIdentity;
        if (ClaimsIdentity != null)
        {
            var Claim = ClaimsIdentity.FindFirst("favColour");
            if (Claim != null && !String.IsNullOrEmpty(Claim.Value))
            {
                FavouriteColour = Claim.Value;
            }
        }
            
        // TODO: Do something with the value and pass to the view model...
        return View();
    }
