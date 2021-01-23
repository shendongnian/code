    [DataContract]
    [Route("/rockstars")]
    public class QueryRockstars : QueryBase<Rockstar>
    {
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
    }
