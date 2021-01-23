    public class YourEntityBusinessLogic
    {
        public List<YourEntity> GetAll()
        {
            var context = new YourDBContext();
            return context.YourEntities.ToList();
        }
    } 
