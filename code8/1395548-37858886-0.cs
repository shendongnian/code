      protected override void Seed(Gamer.DataLayer.GamerContext context)
        {
            GamerData gdata = JsonConvert.DeserializeObject<GamerData>(_json);
            foreach (var game in gdata.Games)
            {
                foreach (var gameGenre in game.GameGenres)
                {
                    Genre myGenre = context.Genres.Where(g => g.GenreId == gameGenre.Genre.GenreId).FirstOrDefault();
                    if (myGenre != null)
                        gameGenre.Genre = myGenre;
                }
                foreach (var platformGame in game.PlatformGames)
                {
                    Platform myPlatform = context.Platforms.Where(p => p.PlatformId == platformGame.Platform.PlatformId).FirstOrDefault();
                    if (myPlatform != null)
                        platformGame.Platform = myPlatform;
                }
                context.Games.Add(game);
                context.SaveChanges();       
            }
           
        }
