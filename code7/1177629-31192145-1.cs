    //this returns all scenarios that have not been played by any of the Users
    var scenarios = await db.PFSScenarios.Where(i => i.PFSCharacterScenarios.Any()).ToListAsync();
    
    //this returns all scenarios that have not been played by any of the User's Chars
    var scenarios = await db.PFSScenarios.Where(i => i.PFSCharacterScenarios.Any(x => userCharacters.Select(z =>.PFSCHARACTERID).Contains(x.PFSCHARACTERID))).ToListAsync();
