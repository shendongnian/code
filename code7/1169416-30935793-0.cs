    public class BenefitsCount
    {
        public int ClientId { get; set; }
        public int BenefitsCount { get; set; }
    }
    
    clients.Clients.Select(i => new BenefitsCount {
         ClientId = i.ClientId,
         BenefitsCount = i.Benfits.Count()
    });
