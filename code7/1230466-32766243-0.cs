    [DataContract(Name ="GAME")]
    public class Game
    {
        [DataMember(Name = "OBJECTS")]
        List<GameObject> Objects { get; set; }
        [DataMember(Name = "EVENTS")]
        List<GameEvent> Events { get; set; }
    }
