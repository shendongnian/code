    [JsonObject(MemberSerialization.Fields)]
    public partial class Distance
    {
        [JsonIgnore]
        private DistanceEqualityStrategy _equalityStrategy;
        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            this._equalityStrategy = _chooseDefaultOrPassedStrategy(this._equalityStrategy);
        }
    }
