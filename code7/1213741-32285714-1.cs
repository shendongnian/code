    public class Class1
    {
        public void UpdateMethod1()
        {
            UpdateWrapper(entities => {
                //insert some items or make some changes in entity
            }); 
        }
        public void UpdateMethod2()
        {
            UpdateWrapper(entities => {
                //insert some items or make some changes in entity
            });                       
        }
        
        private static void UpdateWrapper(Action<StaticDataEntities> update)
        {
            var entities = new StaticDataEntities();
            update(entities);
            entities.SaveChanges();
        }
    }
