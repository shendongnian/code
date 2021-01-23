    public class TransactionDetail
    {
        // all properties related to transaction detail record
        public int TransactionDetailId { get; set; }
        public decimal? Monto { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }  
        // all properties related to Transaction
        public Transaction ParentTransaction { get; set; }
    }
