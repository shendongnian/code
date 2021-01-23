    public class Dado
    {
    	public string localidade { get; set; }
    	public string populacao { get; set; }
    	public string nome_localidad_pai { get; set; }
    	
    	[JsonConverter(typeof(AnoConverter))]
    	public string ano { get; set; }
    }
