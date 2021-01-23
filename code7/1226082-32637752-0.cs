    public class ThingDaoMongoDbImpl : AbstractMongoDbDao<ThingMongoDbImpl>, IThingDao
    {
        public IThing FindByName( String a_Name )
        {
            // Do the lookup and return value
            return new ThingMongoDbImpl();
        }
         T Save( T a_Value ) { //implement it
         }
         void Update( T a_Value ) { 
         //implement it here
         }
         void Delete( T a_Value ) { // implement it here}
         T Find( Object a_Key ) { //implement it}
    }
