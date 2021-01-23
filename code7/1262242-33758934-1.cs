    public class Result{
        public int refno { get; set; }
        public int OrgId { get; set; }
        public string typeCode { get; set; }
        public string fullnames { get; set; }
    }
    var date = new DateTime("01/06/2015");
    var result = Transactions.Where(x => x.TransactionDate >= date && 
        !Transactions.Where(y => y.TransactionDate < date)
                .Select(y => y.OrgId).Contains(x.OrgId))
            .Select(x => new Result(){
                refno = x.refno,
                OrgId = x.OrgId,
                typeCode = x.typeCode,
                fullnames = x.fullnames
            });
