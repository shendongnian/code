            public List<Entity> DoWorkOnSubset(List<General> generals, params string properties)
        {
            List<Entity> entityList = new List<Entity>();
            foreach(var general in generals)
            {
                var entity = new Entity();
                foreach(var prop in properties)
                {
                   entity[prop] = general[prop];
                }
                entityList.Add(entity);
            }
           return entityList;
        }
