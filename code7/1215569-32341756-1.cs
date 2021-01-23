        void Test()
        {
            Expression<Func<Entity, object>> exp = (x) => x.Text;
            List<Entity> entities = new List<Entity>();
            entities.Add(new Entity()
            {
                Id = 1,
                Text = "yacoub"
            });
            entities.Add(new Entity()
            {
                Id = 2,
                Text = "adam"
            });
            DataClass<Entity> data = new DataClass<Entity>(entities.AsQueryable());
            var result = data.GetSorted(exp, 0, 5, null);
        }
