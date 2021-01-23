    public class Cliente
    {    
        ...
        //public IList<Medidor> ListaMedidores { get; set; }    
        //public Medidor Medidor { get; set; }    
    }
    
    public class Medidor
    {
        ...
        //public virtual Cliente Cliente { get; set; }
        public virtual IList<Cliente> Clientes { get; set; }
    }
