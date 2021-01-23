            List<string> urls = new List<string>
                                {
                                    "http://soccer.net/2014-2015/results/",
                                    "http://soccer.net/2013-2014/results/",
                                    "http://soccer.net/2015-2016/results/"
                                };
            List<Games> games = new List<Games>();
            foreach (string url in urls)
            {
                var currentData = htmlWeb.Load("url");
                var currentListOfGames =
                    currentData.DocumentNode.SelectNodes("@class = 'abc'").Select(a => new Game()
                                                                                       {
                                                                                           Date = a.SelectNodes("./a/div/div[1]/span").Single().InnerText.Trim(),
                                                                                           //....
                                                                                       });
                games.AddRange(currentListOfGames);
            }
