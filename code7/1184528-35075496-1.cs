    public class MyEntity
    {
        public static Expression<Func<MyEntity, bool>> IsDeprecated = (myEntity) => myEntity.Deprecated != 0;
        public static Expression<Func<MyEntity, bool>> IsNotDeprecated = (myEntity) => myEntity.Deprecated == 0;
        public integer Deprecated{ get; set; }
    }
    //Then in Linq
    db.MyEntities.Where(MyEntity.IsDeprecated);
   
    //and
    db.MyEntities.Where(MyEntity.IsNotDeprecated);
