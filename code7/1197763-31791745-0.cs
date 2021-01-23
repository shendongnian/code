	void Main()
	{
		var items = new List<Material>
		{ 
		new Material{ MaterialKind = MaterialType.Iron},
		new Material{ MaterialKind = MaterialType.Plastic},
		new Material{ MaterialKind = MaterialType.Carbon},
		new Material{ MaterialKind = MaterialType.Iron},
		new Material{ MaterialKind = MaterialType.Wood},
		};
		
		Material.IsItemsListDistinct(items).Dump();	
	}
	// Define other methods and classes here
	public class Material
	{
	  public MaterialType MaterialKind {get;set;}
	  
	  public static bool IsItemsListDistinct(IList<Material> materialsList) {
	  	return materialsList.GroupBy(x => x.MaterialKind).Any(x => x.Count() > 2);
	  }
	}
	public enum MaterialType
	{
	   Iron,
	   Plastic,
	   Carbon,
	   Wood
	}
