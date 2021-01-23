using System.Collections.Generic;
using Facebook.MiniJSON;
public class MiniJsonParsingExample
{
    public static List<Player> parseResponse(string responseText)
    {
        var resultDict = Json.Deserialize(responseText) as Dictionary<string, object>;
        var players = new List<Player>();
        if (resultDict.ContainsKey("stats"))
        {
            var playerDict = resultDict["stats"] as Dictionary<string, object>;
            foreach (string playerId in playerDict.Keys)
            {
                var psuedoPlayer = playerDict[playerId] as Dictionary<string, object>;
                string playerName = psuedoPlayer["name"] as string;
                long playerRank = (long) psuedoPlayer["rank"];
                string playerScore = psuedoPlayer["score"] as string;
                players.Add(new Player(playerId, playerName, playerRank, playerScore));
            }
        }
        return players;
    }
    public class Player
    {
        string id;
        string name;
        long rank;
        string score;
        public Player(string id, string name, long rank, string score)
        {
            this.id = id;
            this.name = name;
            this.rank = rank;
            this.score = score;
        }
    }
}
