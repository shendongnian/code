    void Main()
    {
    	string json = @"{
    		""id"": ""9286"",
    ""nome"": ""Bairro Novo"",
    ""num_lotes"": ""312"",
    ""num_quadras"": ""9"",
    ""plots_id"": ""159351"",
    ""geo_data"": [
      {
        ""loteamentos_id"": ""9286"",
        ""G"": ""-7.27087569384820000000"",
        ""K"": ""-34.90980863571200000000"",
        ""index"": ""0"",
        ""code"": ""V""
      },
      {
    	""loteamentos_id"": ""9286"",
        ""G"": ""-7.27234968660550000000"",
        ""K"": ""-34.90971207618700000000"",
        ""index"": ""1"",
        ""code"": ""V""
      },
      {
    	""loteamentos_id"": ""9286"",
        ""G"": ""-7.27317448188540000000"",
        ""K"": ""-34.90458905696900000000"",
        ""index"": ""2"",
        ""code"": ""V""
      },
      {
    	""loteamentos_id"": ""9286"",
        ""G"": ""-7.27176434710060000000"",
        ""K"": ""-34.90472316741900000000"",
        ""index"": ""3"",
        ""code"": ""V""
      },
      {
    	""loteamentos_id"": ""9286"",
        ""G"": ""-7.27202508786680000000"",
        ""K"": ""-34.90719884634000000000"",
        ""index"": ""15"",
        ""code"": ""C""
      }
    ]
      }";
      
     var result = JsonConvert.DeserializeObject<RootObject>(json);
    }
    
    public class GeoData
    {
    	public string loteamentos_id { get; set; }
    	public string G { get; set; }
    	public string K { get; set; }
    	public string index { get; set; }
    	public string code { get; set; }
    }
    
    public class RootObject
    {
    	public string id { get; set; }
    	public string nome { get; set; }
    	public string num_lotes { get; set; }
    	public string num_quadras { get; set; }
    	public string plots_id { get; set; }
    	public List<GeoData> geo_data { get; set; }
    }
