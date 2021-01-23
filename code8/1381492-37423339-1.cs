       [HttpGet]
        [Route("api/items/")]
        public ICollection<MyEntityName> selectStudents()
        {            
            /* forget all the stored procedure stuff for the moment */
            ICollection returnItems = new List<MyEntity>();
             MyEntityName e1 = new MyEntityName() { LastName = "Smith" };
             MyEntityName e2 = new MyEntityName() { LastName = "Jones" };
             MyEntityName e3 = new MyEntityName() { LastName = "Winkler" };
             returnItems.Add(e1);
             returnItems.Add(e2);
             returnItems.Add(e3);
             return returnItems;
        }
