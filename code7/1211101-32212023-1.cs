    public abstract class ConverterClassUtils<TClass> 
    	where TClass : class
    {
    	public class ViewConverter<TInner> where TInner : struct, TClass
    	{
    		public static List<EnumView> ConvertToView()
    		{
    			List<EnumView> enumViews = new List<EnumView>();
    
    			TInner[] enumValues = (TInner[])Enum.GetValues(typeof(TInner));
    
    			foreach (var enumValue in enumValues)
    			{
    				var enumView = new EnumView
    				{
    					Id = (int)(object)enumValue,
    					Name = Enum.GetName(typeof(TInner), enumValue)
    				};
    
    				enumViews.Add(enumView);
    			}
    			return enumViews;
    		}
    	}
    }
    
    public class EnumConverter : ConverterClassUtils<Enum> { }
