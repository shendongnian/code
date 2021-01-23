    [DataContract(Namespace = "http://schemas.stackoverflow.com/core/persons/2018/11/14/criterias")]
    public class PersonNameCriteria : BasePersonCriteria
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract(Namespace = "http://schemas.stackoverflow.com/core/persons/2018/11/14/criterias")]
    [KnownType(typeof(PersonNameCriteria))]
    public abstract class BaseAccountCriteria
    {
    }
    [DataContract(Namespace = "http://schemas.stackoverflow.com/core/persons/2018/11/14/requests")]
    public class GetPersonRequest
    {
        [DataMember(IsRequired = true)]
        public BasePersonCriteria PersonCriteria { get; set; }
    }
