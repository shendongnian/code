    public class Producto 
    {
         [JsonProperty("desc")]
         public string Descripcion{get;set;}
    
         [JsonProperty("cant")]
         public int Cantidad{get;set;}
    
         [JsonProperty("cu")]
         public int CostoPorUnidad{get;set;}
    }
