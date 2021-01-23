    [Tables(nome: "SZACONFIG", descricao: "Configurações plugins", tipo: BoUTBTableType.bott_NoObject, tabelaSistema: false)]
    public class Configuracoes : TableBase
    {
        [Fields("NomeUsu", "Nome de Usuário", 150, true, BoFldSubTypes.st_None)]
        public string NomeUsuario { get; set; }
    
        [Fields("NomePlg", "Nome do Plugin", 200, true, BoFldSubTypes.st_None)]
        public string NomePlugin { get; set; }
    
        [Fields("Ativo", "Ativo", 1, false, BoFldSubTypes.st_None)]
        [ValoresValidos("N", "Não")]
        [ValoresValidos("Y", "Sim")]
        public string Ativo { get; set; }
        
    
    
    }
