    public class EmpTraining
    {
    	[JsonProperty('CODCOLIGADA')]
        public int CodColig { get; set; }
    	[JsonProperty('CHAPA')]	
        public string EmpID { get; set; }
    	[JsonProperty('NOME')]		
        public string Employee { get; set; }
    	[JsonProperty('CCUSTO')]			
        public string CostCenter { get; set; }
    	[Jsonproperty('Departamento')]
        public string Department { get; set; }
    	[JsonProperty('CODPOSTO']
        public string WorkstationID { get; set; }
    	[JsonProperty('POSTO')]
        public string Workstation { get; set; }
    	[JsonProperty('TREINAMENTO')]
        public string Training { get; set; }	
    	[JsonProperty('REALIZADO_EM')]	
        public string CreateDt { get; set; }
    	[JsonProperty('VALIDADE')]	
        public string DueDt { get; set; }
    }
