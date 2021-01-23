    public partial class Modelo
    {
        public ICollection<FuncaoUsuario> ProductDevelopment { get; set; }
        //Continua...
    }
    public class FuncaoUsuario 
    {
        public int IdFuncao { get; set; }
        public string Usuario { get; set; }
        public string DscFuncao { get; set; }
    }
