	public interface ILocalEntityListProvider {
		List<object> GetLocal(string name, DbContext ctx);
	}
	public class LocalEntityListProvider<TEntity> : ILocalEntityListProvider {
		private List<TEntity> GetLocal(string name, DbContext ctx)
		{
			var enumerable = (IEnumerable<TEntity>)(typeof([ClassNameOfMyContext]).GetProperty(name).GetValue(ctx, null));
			return enumerable.ToList();
		}
		
		List<object> ILocalEntityListProvider.GetLocal(string name, DbContext ctx) {
			return GetLocal(name, ctx).Cast<object>().ToList();
		}
	}
	var dbSetPropertiesLocal = local.GetDbSetProperties();                
	foreach (var item in dbSetPropertiesLocal)
	{
		var providerClassType = typeof(LocalEntityListProvider<>).MakeGeneric(item.PropertyType);
		var providerInstance = Activator.CreateInstance(providerClassType) as ILocalEntityListProvider;
		var enumerable = providerInstance.GetLocal(item.Name, local);  
	}  
