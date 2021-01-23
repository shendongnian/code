    [Route("/search")]
    public class QueryPerson : QueryBase<Person> {}
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
    var response = "http://example.org/search"
        .AddQueryParam("first_name", "Jimi")
        .GetJsonFromUrl()
        .FromJson<QueryResponse<Person>>();
    response.PrintDump();
