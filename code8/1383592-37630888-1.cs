    if (this.User.Identity.IsAuthenticated)
    {
        Debug.WriteLine("Claims:");
        var identity = this.User.Identity as ClaimsIdentity;
        foreach (var claim in identity.Claims)
        {
            Debug.WriteLine(claim.Type + " - " + claim.Value);
        }
    }
