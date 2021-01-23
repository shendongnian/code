                if(matchGame == null)
                {
                    // Only do this if the serial is not null
                    if (i["serial"].Type != JTokenType.Null)
                    {
                       Console.WriteLine(i["serial"].ToString());
                       var Game = new RentGame(i["item"]["name"].ToString(), i["id"].ToString(), i["serial"].ToString());
                       rentGame.Add(Game);
                       Console.WriteLine("Add rent game " + Game.name);
                }
