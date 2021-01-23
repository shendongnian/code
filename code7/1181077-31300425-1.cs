    public class Cliente
    {    
        public virtual int ClienteId { get; set; }  
        public virtual IList<Medidor> ListaMedidores { get; set; }   
        public virtual string NumeroMedidor { get; set; }       
    }
    public class Medidor
    {
        public virtual string NumeroMedidor { get; set; }
        public virtual string MarcaMedidor { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
