    [DataContract]
    public class PublicCliente
    {
        [DataMember(Order = 1)]
        public int Id;
        [DataMember(Order = 2)]
        public string Name;
        public PublicCliente(Cliente c)
        {
            Id = c.Id;
            Name = c.Name;
        }
    }
