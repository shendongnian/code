    public class excelInventory
            {
                public excelInventory(){
                    cols = new List<decimal>();
                }
                public string code { get; set; }
                public string description { get; set; }
                public List<decimal> cols{get;set;}
             }
