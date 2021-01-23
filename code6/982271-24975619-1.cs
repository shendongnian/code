    public static Summoner getRecentGames(string summonerId)
    {
        try
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://eu.api.pvp.net/api/lol/euw/v1.4/summoner/by-name/"+summonerId+"?api_key="+api_key);
                var wrapper = JsonConvert.DeserializeObject<Wrapper>(json);
                return wrapper.SummonerName;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        return null;
    }
