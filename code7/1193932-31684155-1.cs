    [DataContract]
    public class Result
    { 
        private ResultDecisionStatus? _decisionStatus;
        [DataMember(Order = 3)]
        public bool? Accepted { get; set; }
        [DataMember(Order = 4)]
        public ResultDecisionStatus DecisionStatus 
        { 
            get
            {
                if (_decisionStatus.HasValue)
                {
                    return _decisionStatus.Value;
                }
                else if (Accepted.HasValue)
                {
                    return Accepted.Value 
                        ? ResultDecisionStatus.Accepted 
                        : ResultDecisionStatus.Rejected;
                }
                else
                {
                    return ResultDecisionStatus.Unknown;
                }
            }
            set
            {
                _decisionStatus = value;
            }
        }
    }
