    public class MyEntityRepository
    {
        private readonly AppDbContext dbContext;
        public MyEntityRepository(AppDbContext context)
        {
            dbContext = context;
        }
    
        public MyEntityDto Create()
        {
            var newEntity = new MyEntity();
            dbContext.MyEntities.Add(newEntity);
    
            var newEntityDto = Mapper.Map<MyEntityDto>(newEntity);
    
            return newEntityDto;
        }
    
        public MyEntityDto Find(int id)
        {
            var myEntity = dbContext.MyEntities.Find(id);
    
            if (myEntity == null)
                return null;
    
            var myEntityDto = Mapper.Map<MyEntityDto>(myEntity);
    
            return myEntityDto;
        }
    
        public MyEntityDto Save(MyEntityDto myEntityDto)
        {
            var myEntity = Mapper.Map<MyEntity>(myEntityDto);
    
            dbContext.MyEntities.Save(myEntity);
    
            return Mapper.Map<MyEntityDto>(myEntity);
        }
    }
