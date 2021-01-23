     public Configuration()
     {
        AutomaticMigrationsEnabled = true;
     }
    protected override void Seed(DataLayer.FootballContext context)
    {
        // Where 'VoetbalPloegs' is the name of your table in the dbcontext
        context.VoetbalPloegs.AddOrUpdate(x => x.Id,
             new VoetbalPloeg() { VoetbalPloegId = 1, PloegNaam = "FC Barcelona", StamNummer = 1241, Spelers =
              {
                  new Speler() { SpelerId = 1, VoorNaam = "Lionel", AchterNaam = "Messi", Assists = 2, Goals = 15, GeboorteDatum = new DateTime(1990, 05, 15), Positie = "Spits", Rugnummer = 10},
                  new Speler() { SpelerId = 2, VoorNaam = "Alonso", AchterNaam = "Xabi", Assists = 3, Goals = 7, GeboorteDatum = new DateTime(1985, 04, 24), Positie = "Centraal", Rugnummer = 13}
              },
            new VoetbalPloeg() { VoetbalPloegId = 2, PloegNaam = "Real Madrid", StamNummer = 1546, Spelers = //etc...
