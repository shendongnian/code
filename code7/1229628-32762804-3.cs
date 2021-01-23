    public class BllLink
    {
        public static void SaveEntity(IAuditableEntity entity)
        {
            entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
            if(String.IsNullOrEmpty(entity.CreatedBy)) //assume new
            {
                entity.CreatedBy = HttpContext.Current.User.Identity.Name;
            }
            Bll.SaveEntity(entity); //you might need to use generics
        }
    }
