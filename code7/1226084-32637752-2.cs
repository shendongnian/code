      public class ThingCassandraImpl : AbstractCassandraBase, IThing, IBaseCassandra, IThingDao
        {
            public String Name { get; set; }
            public IThing Save(IThing a_Value)
            {
                throw new NotImplementedException();
            }
    
            public void Update(IThing a_Value)
            {
                throw new NotImplementedException();
            }
    
            public void Delete(IThing a_Value)
            {
                throw new NotImplementedException();
            }
    
            public IThing Find(object a_Key)
            {
                throw new NotImplementedException();
            }
    
            public IThing FindByName(string a_Name)
            {
                throw new NotImplementedException();
            }
        }
        public abstract class AbstractCassandraDao<T> where T : IBaseCassandra,IThingDao, new() 
        {
            public T Save(T a_Value)
            {
                // Save
                return a_Value;
            }
            public void Update(T a_Value)
            {
                // Update
            }
            public void Delete(T a_Value)
            {
                // Delete
            }
            public T Find(Object a_Key)
            {
                return new T();
            }
        }
    
        public class ThingDaoCassandraImpl : AbstractCassandraDao<ThingCassandraImpl>
        {
            public IThing FindByName(String a_Name)
            {
                // Do the lookup and return value
                return new ThingCassandraImpl();
            }
    
            public IThing Save(IThing a_Value)
            {
                throw new NotImplementedException();
            }
    
            public void Update(IThing a_Value)
            {
                throw new NotImplementedException();
            }
    
            public void Delete(IThing a_Value)
            {
                throw new NotImplementedException();
            }
    
            public IThing Find(object a_Key)
            {
                throw new NotImplementedException();
            }
        }
