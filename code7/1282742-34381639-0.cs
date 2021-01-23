    public class Team
    {
       public int TeamId {get;set;}
       public string TeamName {get;set;}
       public string SportType {get;set;}
       public virtual List<Player> Players {get;set;}
    }
    
    public class Player
    {
       public int PlayerId {get;set;}
       public string Name {get;set;}
       public int Age {get;set;}
       public double Salary {get;set;}
       public string Gender {get;set;}
    
       [ForeignKey("TeamId")]
       public virtual Team Team {get;set;}
    }
