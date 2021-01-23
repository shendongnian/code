        Regex IssuedRegex = new Regex(@"\""\.issued\"":\s*\""([^\""]+)\""");
        Regex ExpiresRegex = new Regex(@"\""\.expires\"":\s*\""([^\""]+)\""");
        var response = authClient.Execute<AccessToken>(request);
        AccessToken = response.Data;
        // workaround for bug in RestSharp
        var im = IssuedRegex.Match(response.Content);
        if (im.Success)
            AccessToken.Issued = DateTime.ParseExact(im.Groups[1].Value, "R", CultureInfo.InvariantCulture);
        var em = ExpiresRegex.Match(response.Content);
        if (em.Success)
            AccessToken.Expires = DateTime.ParseExact(em.Groups[1].Value, "R", CultureInfo.InvariantCulture);
