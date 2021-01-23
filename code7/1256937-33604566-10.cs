    public class RetrieveSanctionPartyListResponse : BaseResponse
    {
        [DataMember]
        public RetrieveSanctionPartyList RetrieveSanctionPartyList { get; set; }
        public override void print()
        {
            base.print();
            Console.WriteLine("[RetrieveSanctionPartyList.Spl] " + RetrieveSanctionPartyList.Spl);
            Console.WriteLine("[RetrieveSanctionPartyList.Tech] " + RetrieveSanctionPartyList.Tech);
            Console.WriteLine("[RetrieveSanctionPartyList.PartnerId] " + RetrieveSanctionPartyList.PartnerId);
        }
    }
