    var user = new User
    {
        Username = this.User.Identity.Name.Substring(0,9) + this.User.Identity.Name.Substring(9, name.Length - 9).ToLower(),
        IsAuthenticated = this.User.Identity.IsAuthenticated
    };
