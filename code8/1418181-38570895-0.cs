    public async Task<returntyp> Name()
    {
      DynamicCrest crest = new DynamicCrest();
      var root = await crest.GetAsync(crest.Host);
      var alliancelookup = await (await root.GetAsync(r => r.alliances)).First(i => i.shortName == e.GetArg("allianceticker").ToUpper());
      allianceid = alliancelookup.id;
