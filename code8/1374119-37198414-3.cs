     public Configuration()
     {
        AutomaticMigrationsEnabled = true;
     }
     protected override void Seed(TestContext context)
        {
            // Where 'VoetbalPloegs' is the name of your table in the dbcontext
            context.Spelers.AddOrUpdate(x => x.Id,
                new Speler() { Id = 1, VoorNaam = "Lionel", AchterNaam = "Messi", Assists = 2, Goals = 15, GeboorteDatum = new DateTime(1990, 05, 15), Positie = "Spits", Rugnummer = 10, VoetbalPloegId = 1 },
                new Speler() { Id = 2, VoorNaam = "Alonso", AchterNaam = "Xabi", Assists = 3, Goals = 7, GeboorteDatum = new DateTime(1985, 04, 24), Positie = "Centraal", Rugnummer = 13, VoetbalPloegId = 1},
                new Speler() { Id = 3, VoorNaam = "Cristano", AchterNaam = "Ronaldo", Assists = 0, Goals = 17, GeboorteDatum = new DateTime(1989, 10, 7), Positie = "Spits", Rugnummer = 7, VoetbalPloegId = 2 },
                new Speler() { Id = 4, VoorNaam = "Sergio", AchterNaam = "Ramos", Assists = 0, Goals = 4, GeboorteDatum = new DateTime(1986, 12, 04), Positie = "LaatsteMan", Rugnummer = 10, VoetbalPloegId = 2}
                );
            context.VoetbalPloegs.AddOrUpdate(x => x.Id,
                new VoetbalPloeg() { Id = 1, PloegNaam = "FC Barcelona", StamNummer = 1241 },
                new VoetbalPloeg() { Id = 2, PloegNaam = "Real Madrid", StamNummer = 1546 }
               );
        }
