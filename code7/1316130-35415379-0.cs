	public class logis
	{
		public string codigo { get; set; }
		public List<decimal> Necesidades { get; set; }
		decimal SumaNecesidades{get;set;}
		public logis() 
		{ 
			this.Necesidades = new List<decimal>(); 
		}
	}
