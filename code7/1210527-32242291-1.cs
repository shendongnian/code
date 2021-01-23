    public class ProfilePrivilege
    {
        ...
        [JsonConverter(typeof(SpaceListConverter))]
        public List<Guid> Spaces;
        ...
    }
