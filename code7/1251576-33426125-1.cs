      public class CallListComparer : IEqualityComparer<UnansweredCallList>
        {
            public bool Equals(UnansweredCallList x, UnansweredCallList y)
            {
                return x.PhoneNumber == y.PhoneNumber && y.AgentAnswerTime != "null" || x.AgentAnswerTime != "null";
            }
    
            public int GetHashCode(UnansweredCallList obj)
            {
                return obj.PhoneNumber.GetHashCode();
            }
        }
