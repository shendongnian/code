    public class GameStats
        {
            public List<BasePlayer> players { get; set; }
            public RadiantTeam radiant_team { get; set; }
            public DireTeam dire_team { get; set; }
            public GameStats(){
              dire_team = new DireTeam();
              radiant_team = new RadiantTeam();
            }
        }
