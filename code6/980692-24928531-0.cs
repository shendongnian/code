    public interface ICategoryOrTag
    {
      string Name  {get; set;}
      DateTime DateAdded  {get; set;}
      DateTime LastModifiedDate  {get; set;}
      bool  IsDeleted  {get; set;}
    }
    public class Category : ICategoryOrTag
    {
      //Category specific 
    }
    public class Tag : ICategoryOrTag
    {
      //Tag specific 
    }
    public void AddEntityDontExist<T>(string entities) where T : ICategoryOrTag
        {
            var allEntities = entityRepo<T>.GetAllQueryAble();
            string[] entity = entities.Split(',');
    
            foreach (var item in entity)
            {
                if (allEntities.Where(e => e.Name.Contains(item)).ToArray().Count() == 0)
                {
                    entityRepo.Add(new T
                    {
                        Name = item.ToString(),
                        DateAdded = DateTime.Now,
                        LastModifiedDate = DateTime.Now,
                        IsDeleted = false
                    });
                }
            }
        }
