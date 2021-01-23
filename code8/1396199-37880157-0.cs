     <Code>public interface IEntity {
		Guid Id {get;set;}
	 }
     public static T Add<T>(T entity) where T:class, IEntity {
     	Context.Set<T>().Add(entity);
     	Context.SaveChanges();
    	return Context.Set<T>().Find(entity.Id);
     }</Code>
