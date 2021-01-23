            //Broader/Narrower example
            var music = new Authority { Term = "Music"};
            var jazz = new Authority { Term = "Jazz Music" };
            var classical = new Authority { Term = "Classical Music" };
            music.Narrower.Add(jazz);
            music.Narrower.Add(classical);
            jazz.Broader.Add(music);
            classical.Broader.Add(music);
            //Equivalent example
            var zucchini = new Authority { Term = "Zucchini" };
            var courgette = new Authority { Term = "Courgette" };
            zucchini.Equivalent.Add(courgette);
            courgette.Equivalent.Add(zucchini);
            context.Authority.Add(music);
            context.Authority.Add(jazz);
            context.Authority.Add(classical);
            context.Authority.Add(zucchini);
            context.Authority.Add(courgette);
            context.SaveChanges();
