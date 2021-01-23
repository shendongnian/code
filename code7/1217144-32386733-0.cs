        using System.Collections.Generic;
        public class Team{
            public string Name {get;set;}
            public int score {get;set;}
            }
            //Create some dummy data
        public List<Team> lstTeam = new List<Team>{
            new Team{Name="A", score=1},
            new Team{Name="A", score=1},
            new Team{Name="B", score=1},
            new Team{Name="C", score=2},
            new Team{Name="A", score=2},
            new Team{Name="C", score=2}
            
            };   
    
         List<Team> lstDistictTeams = lstTeam.Distinct<Team>(new DistinctComparer()).ToList();
         foreach(Team t in lstDistictTeams)
         {
             Console.WriteLine("Team {0} has Score {1}",t.Name,t.score);
             }
    
    //This class provides a way to compare two objects are equal or not
         public class DistinctComparer : IEqualityComparer<Team>
            {
                public bool Equals(Team x, Team y)
                {
                    return (x.Name == y.Name && x.score == y.score); // Here you compare properties for equality
                }
                public int GetHashCode(Team obj)
                {
                    return (obj.Name.GetHashCode() + obj.score.GetHashCode());
                }
            } 
