    public class Entity<TKey> : IEntity
    {              
    [System.Runtime.Serialization.DataMemberAttribute]
    public TKey Id { get; set; }
    [System.Runtime.Serialization.DataMemberAttribute]
    public StateEnum State { get; set; }}
    public class Party : Entity<int>
    {
    public int TypeId { get; set; }
    public string MobileNo1 { get; set; }}
    public class Person
    {
    [Key]
    [ForeignKey("Party")]
    public int PartyId { get; set; }
    public string Name { get; set; }
    public virtual Party Party {get; set;}
    }
