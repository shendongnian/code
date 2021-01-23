	public struct HydroObjectIdentifier
	{
		public string Name { get; set; }
		public string TypeName { get; set; }
		
		public override string ToString()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(this);
		}
		public HydroObjectIdentifier(string name, string typeName)
		{
			this.Name = name;
			this.TypeName = typeName;
		}
	}
