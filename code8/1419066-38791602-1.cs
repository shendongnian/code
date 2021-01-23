    [Tables("OUSR", "Cadastro de Usuários", true)]
        public class OUSR : TableBase
        {
            
             
            [Fields("AdmPlg", "Administrar Plugin", 1, "N", false, BoFldSubTypes.st_None)]
            [ValoresValidos( "N", "Não")]
            [ValoresValidos( "S", "Sim")]
            public string AdmPlg { get; set; }
    
            
            
    
        }
