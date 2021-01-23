    public class PlayerModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var context = DependencyResolver.Current.GetService<DbContext>();
                var id = ModelBinderHelpers.GetA<Guid>(bindingContext, "id");
    
                if (id == null || !id.HasValue)
                    throw new HttpException(404, "Not found");
    
                var entity = context.Set<Player>()
                    .Include(x => x.Brand)
                    .FirstOrDefault(x => x.Id == id);
    
                if (entity == null)
                    throw new HttpException(404, "Not found");
    
                return entity;
            }
        }
