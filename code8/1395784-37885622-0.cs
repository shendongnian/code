   	void Main()
	{
	
		List<exampleClass> EnfSist = new List<exampleClass>();
		EnfSist.Add(new exampleClass { name = "ap_enf_id_enfermedad", value = "12" });
		EnfSist.Add(new exampleClass { name = "apap_pac_inicio"		, value = "34" });
    	 // etc
	
		tbl_sistematicas b = new tbl_sistematicas();
		b.InjectFrom<MyInjection>(EnfSist);
		 	
	}
	 
	
	
	public class MyInjection : KnownSourceValueInjection<List<exampleClass>>
	{
		protected override void Inject(List<exampleClass> source, object target)
		{	 
			foreach(var entry in source)
			{			 			
				var property = target.GetProps().GetByName(entry.name, true);
				if (property != null) 
					property.SetValue(target, Convert.ChangeType(entry.value, property.PropertyType));
			}
		}
	}
	
    public class exampleClass
	{
		public string name { get; set; }
		public string value { get; set; }
	}
	
	public class tbl_sistematicas
	{
		public int ap_enf_id_enfermedad  	 { get; set; } 
		public int apap_pac_inicio 			 { get; set; } 
		public int ap_pac_inicio_periodo 	 { get; set; } 
		public int ap_pac_duracion		  	 { get; set; } 
		public int ap_pac_duracion_periodo	 { get; set; } 
		public string ap_pac_tratamiento	 { get; set; } 
	} 
