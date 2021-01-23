    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, AsReferenceDefault = true)]
    public class ST : Base
    {
        public string Id { get; set; }
        [ProtoMember(401, AsReference = true)]
        public List<SI> Indexes { get; set; }
    }
