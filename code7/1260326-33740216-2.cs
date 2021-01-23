    public class TransactionDetail
    {
        // all properties related to Transaction
        public int TransaccionId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int AutorizaId { get; set; }
        public int ConfeccionaId { get; set; }
        public int CentroCostoId { get; set; }
        public Usuario Autoriza { get; set; }
        public Usuario Confecciona { get; set; }
        // all properties related to transaction detail record
        public int TransactionDetailId { get; set; }
        public int ParentTransactionId { get; set; }
        public decimal? Monto { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }  
    }
