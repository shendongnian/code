    public struct ManufacturerValue
    {
    	public int ManufacturerID;
    	public string Name;
    	public string CustomSlug;
    	public string Title;
    	public string Description;
    	public string Image;
    	public string SearchFilters;
    	public int TopZoneProduction;
    	public int TopZoneTesting;
    	public int ActiveProducts;
    }
    
    public struct ManufacturerValueRef
    {
    	public readonly ManufacturerValue[] Source;
    	public readonly int Index;
    	public ManufacturerValueRef(ManufacturerValue[] source, int index) { Source = source; Index = index; }
    	public int ManufacturerID => Source[Index].ManufacturerID;
    	public string Name => Source[Index].Name;
    	public string CustomSlug => Source[Index].CustomSlug;
    	public string Title => Source[Index].Title;
    	public string Description => Source[Index].Description;
    	public string Image => Source[Index].Image;
    	public string SearchFilters => Source[Index].SearchFilters;
    	public int TopZoneProduction => Source[Index].TopZoneProduction;
    	public int TopZoneTesting => Source[Index].TopZoneTesting;
    	public int ActiveProducts => Source[Index].ActiveProducts;
    }
    
    public static partial class Utils
    {
    	public static IEnumerable<ManufacturerValueRef> AsRef(this ManufacturerValue[] values)
    	{
    		for (int i = 0; i < values.Length; i++)
    			yield return new ManufacturerValueRef(values, i);
    	}
    }
