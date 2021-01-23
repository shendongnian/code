     public Configuration()
     {
        AutomaticMigrationsEnabled = true;
     }
     protected override void Seed(TestContext context)
     {
        // Where 'VoetbalPloegs' & 'Spelers' are the name of your tables in the dbcontext
            context.Spelers.AddOrUpdate(x => x.SpelerId,
                new Speler() { SpelerId = 1, VoorNaam = "Lionel", AchterNaam = "Messi", Assists = 2, Goals = 15, GeboorteDatum = new DateTime(1990, 05, 15), Positie = "Spits", Rugnummer = 10 },
                new Speler() { SpelerId = 2, VoorNaam = "Alonso", AchterNaam = "Xabi", Assists = 3, Goals = 7, GeboorteDatum = new DateTime(1985, 04, 24), Positie = "Centraal", Rugnummer = 13 },
                new Speler() { SpelerId = 3, VoorNaam = "Cristano", AchterNaam = "Ronaldo", Assists = 0, Goals = 17, GeboorteDatum = new DateTime(1989, 10, 7), Positie = "Spits", Rugnummer = 7 },
                new Speler() { SpelerId = 4, VoorNaam = "Sergio", AchterNaam = "Ramos", Assists = 0, Goals = 4, GeboorteDatum = new DateTime(1986, 12, 04), Positie = "LaatsteMan", Rugnummer = 10 }
                );
            context.VoetbalPloegs.AddOrUpdate(x => x.VoetbalPloegId,
                new VoetbalPloeg() { VoetbalPloegId = 1, PloegNaam = "FC Barcelona", StamNummer = 1241, Spelers = {  } },
                new VoetbalPloeg() { VoetbalPloegId = 2, PloegNaam = "Real Madrid", StamNummer = 1546, Spelers = { } }
               );
        }
