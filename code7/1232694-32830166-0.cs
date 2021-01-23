	private static IMappingExpression<TModel, TEntity> MapEntityWithContactInfo<TModel, TEntity>(this IMappingExpression<TModel, TEntity> mapping)
		where TModel : EditModelBaseWithContactInfo
		where TEntity : EntityWithContactInfo
	{
		return mapping.MapEntityModifiable()
			.ConvertUsing(x => Mapper.Map<TEntity>(x.ContactInfo));
	}
