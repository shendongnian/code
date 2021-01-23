    public class TableContent 
    {
         public int id { get; set; }
         public string qte { get; set; }
    }
    public class AjourtercommandParam 
    {
         public string NumCommande { get; set; }
         public int client { get; set; }
         public TableContent[] global { get; set; }
    }
