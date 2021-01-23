    //check that if C or P are not matchable, the result is failed.
    Prop.ForAll(genC.ToArbitrary(), genP.ToArbitrary(), (c, p) => {
        var result = MatchService.CreateMatch(new MatchCreationRequest(c, p));
        if (!c.IsMatchable || !p.IsMatchable) { Assert.IsFalse(result.Succesful); }
    }).QuickCheckThrowOnFailure();
