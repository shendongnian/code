	private List<decimal> necesidades = null;
	public List<decimal> Necesidades 
	{ 
		get
		{
			if (this.necesidades == null) { this.necesidades = new List<decimal>(); }
			return this.necesidades;
		}
		set
		{
			if (this.necesidades == null) { this.necesidades = new List<decimal>(); }
			this.necesidades = value;
		}
	}
