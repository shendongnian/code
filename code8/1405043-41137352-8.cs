            //Broader/Narrower example
            var music = new Tag{ Term = "Music"};
            var jazz = new Tag{ Term = "Jazz Music" };
            var classical = new Tag{ Term = "Classical Music" };
            music.Narrower.Add(jazz);
            music.Narrower.Add(classical);
            jazz.Broader.Add(music);
            classical.Broader.Add(music);
            //Equivalent example
            var zucchini = new Tag{ Term = "Zucchini" };
            var courgette = new Tag{ Term = "Courgette" };
            zucchini.Equivalent.Add(courgette);
            courgette.Equivalent.Add(zucchini);
            context.Tags.Add(music);
            context.Tags.Add(jazz);
            context.Tags.Add(classical);
            context.Tags.Add(zucchini);
            context.Tags.Add(courgette);
            context.SaveChanges();
