    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    namespace Observable
    {
        class BowlingTeam
        {
            public string TeamName { get; set; }
            private readonly IList<Player> players = new ObservableCollection<Player>();
            public IList<Player> Players
            {
                get
                {
                    return players;
                }
            }
            public void AddPlayer(string name, int score)
            {
                AddPlayer(new Player(name, score));
            }
            public void AddPlayer(Player p)
            {
                players.Add(p);
            }
            public Player HighestRanked()
            {
                if (Players.Count == 0)
                {
                    // no players
                    return null;
                }
                int max = 0, index = -1;
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].Score > max)
                    {
                        index = i;
                        max = Players[i].Score;
                    }
                }
                if (index < 0)
                {
                    // no players found with a score greater than 0
                    return null;
                }
                return Players[index];
            }
            public BowlingTeam()
            { 
            }
            public BowlingTeam(string teamName)
            {
                this.TeamName = teamName;
            }
        }
        class Player
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public Player()
            {
            }
            public Player(string name, int score)
            {
                this.Name = name;
                this.Score = score;
            }
            public override string ToString()
            {
                return string.Format("{0} {1:n2}", Name, Score);
            }
        }
    }
