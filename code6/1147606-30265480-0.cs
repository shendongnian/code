	class Caster
	{
		internal void Load<T>(List<T> model)
			where T:PointOfSaleModel
		{
			
			// this should work
			var pointOfSalesList = new List<PointOfSaleModel>(model);
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			var list = new List<PointOfSaleModel> {
				new PointOfSaleModel{
					Name = "name 1"
				}
			};
			var caster = new Caster ();
			caster.Load (list);
		}
	}
