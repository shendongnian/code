    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Core.Metadata.Edm;
    
    public class UppercaseColumnNameConvention : IStoreModelConvention<EdmProperty>
    {
    	public void Apply(EdmProperty item, DbModel model)
    	{
    		item.Name = item.Name.ToUpper();
    	}
    }
