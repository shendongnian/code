        public void Add(A a)
        {
            using (My_Entities context = new My_Entities())
            {
                context.tS.Add(new YourDatabaseEntity()
                   {
                      Id = a.id,
                      Name = a.name
                      // etc..
                   });
                context.SaveChanges();
            }
        }
