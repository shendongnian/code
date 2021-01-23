	public class logis
	{
		public string codigo { get; set; }
		decimal SumaNecesidades{get;set;}
	
		private List<decimal> necesidades = null;
		private void initNecesidades() 
		{
			if (this.necesidades == null) 
			{ 
				this.necesidades = new List<decimal>(); 
			}
		}
		public List<decimal> Necesidades 
		{ 
			get
			{
				this.initNecesidades();
				return this.necesidades;
			}
			set
			{
				this.initNecesidades();
				this.necesidades = value;
			}
		}
	}
