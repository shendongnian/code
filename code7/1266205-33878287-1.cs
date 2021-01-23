    static class Factory
    {
        public static Position Get(int id)
        {
            var types = typeof(Position).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(Position)))
                .ToList();
            Position position = null;
            foreach(var type in types)
            {
               // Get the PositionType attribute
               if(correctPosition)
               {
                   position = Activator.CreateInstance(type) as Position;
                   break;
               }
            }
            return position;
        }
    }
