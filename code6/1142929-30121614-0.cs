    [DataContract]
    public class Team
    {
        [DataMember]
        public List<Player> Players { get; set; }
        [DataMember]
        public Player Captain { get; set; }
    }
    
    [DataContract(IsReference = true)]
    public class Player
    {
            
    }
