    protected override void Seed(ApplicationContext context)
    {
        var languageIds = new List<int> {1,2,3,4};  // FK to language. Are you assigning same list to all profiles?
    
        var profiles = context.Profiles.Include(p => p.Languages).ToList();
        foreach (var profile in profiles)
        {
            // Since you mention updating, you may need to remove old languages
            if (profiles.Languages.Any())
            { delete children... }
            
            // add new languages. You could add a test so you only seed when no languages are present
            foreach (var languageId in LanguageIds)
            {
                profile.Add(new Language {LanguageId = languageId};
            }
        }
        context.SaveChanges();
    }
