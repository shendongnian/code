    public enum ResultDecisionStatus
    {
        Rejected = 0, // will catch old boolean false values
        Accepted = 1, // will catch old boolean true values
        Neutral = 2 // new
    }
    [DataContract]
    public class Result
    { 
        [DataMember(Order = 3)]
        public ResultDecisionStatus? DecisionStatus { get; set; } 
    }
