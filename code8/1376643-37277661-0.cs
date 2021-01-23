	public class MyObject
	{
		public int Id { get; set; }
		[JsonProperty("tipoReporte")]
		public int TipoReporte { get; set; }
		[JsonProperty("fecha")]
		public DateTime Fecha { get; set; }
		[JsonProperty("datos")]
		public Dictionary<string, string> Datos { get; set; }
		[JsonProperty("usuarioID")]
		public int UsuarioID { get; set; }
		
		public int Enviado { get; set; }
	}
