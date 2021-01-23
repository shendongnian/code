	internal class Game
    {
        public List<Team> Teams { get; set; } 
        public void firstSpawn(string userName, int teamID)
        {
            if (!PhotonNetwork.isMasterClient)
            {
                return;
            }
            Team team;
            if (Teams.Any(t => t.TeamID == teamID))
            {
                team = Teams.FirstOrDefault(t => t.TeamID == teamID);
            }
            else
            {
                team = new Team(teamID);
                Teams.Add(team);
            }            
            team.Users.Add(new User(userName));
        }
       
        public void playerDied(bool wasBot, bool wasKilledBySomeone, User killer, User dead, Team playerTeam)
        {
            if (PhotonNetwork.isMasterClient)
            {
                if (wasBot)
                {
                    Health hlscBot = GameObject.Find(dead.Name).GetComponent<Health>();
                    hlscBot.GetComponent<PhotonView>().RPC("DeSpawn", PhotonTargets.AllBuffered, "bot", dead.Name, dead.Name, playerTeam);
                }
                else
                {
                    //player respawn stuff here
                    Debug.Log("Host MyMatchData " + dead.Name);
                    Health hlsc = GameObject.Find(playerName).GetComponent<Health>();
                    hlsc.GetComponent<PhotonView>().RPC("DeSpawn", PhotonTargets.AllBuffered, "player", dead.Name, "null", -1);
                }
                //do Score dumping stuff here
                dead.Death(); // The dead is dead, no matter if suicide or not
                if (wasKilledBySomeone)
                {
                    killer.Kill();//increase the killers score
                }
             }
        }
        public bool getTheHigherTeamBy(Types type)
        {
            return Teams.Any(team => team.getTeamScore(type) == Teams.Max(t => t.getTeamScore(type)));
        }
    }
    internal class Team
    {
        public int TeamID { get; set; }
        public List<User> Users { get; set; } 
        public Team(int id = 0)
        {
            TeamID = id;
        }
        public int getTeamScore(Types type)
        {
            return Users.Sum(u => u.Score.getScoreFromType(type));
        }
        public string[] getPlayerNames()
        {
            return Users.Select(u => u.Name).ToArray();
        }
        public string[] GetPlayerNames(Types sortingScoreType)
        {
            return Users.OrderByDescending(u => u.Score.getScoreFromType(sortingScoreType)).Select(u => u.Name).ToArray();
        }
    }
    public enum Types
    {
        Kill,
        Death,
        Assist // Not sure about that one
    }
    internal class Score
    {
        private readonly Dictionary<Types, int> points = new Dictionary<Types, int>();
        public Score()
        {
            // Fill the dictionnary with all the available types
            foreach (Types type in Enum.GetValues(typeof(Types)))
            {
                points.Add(type, 0);
            }
        }
        public int getScoreFromType(Types type)
        {
            return points[type];
        }
        public void incrementScoreForType(Types type, int amount = 1)
        {
            points[type] += amount;
        }
        
    }
    internal class User
    {
        public string Name { get; set; }
        public Score Score { get; set; }
        public User(string name = "Default")
        {
            Name = name;
            Score = new Score();
        }
        public int getScoreFromType(Types type)
        {
            return Score.getScoreFromType(type);
        }
        public void changeScore(Types type, int amount)
        {
            Score.incrementScoreForType(type, amount);
        }
        public void Death()
        {
            Score.incrementScoreForType(Types.Death);
        }
        public void Kill()
        {
            Score.incrementScoreForType(Types.Kill);
        }
        public void Assist()
        {
            Score.incrementScoreForType(Types.Assist);
        }
    }
