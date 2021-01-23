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
               type.GetCustomAttributes<PositionTypeAttribute>();
               if(type.PositionId == id)
               {
                   position = Activator.CreateInstance(type) as Position;
                   break;
               }
            }
            if(position == null)
            {
                var message = $"Could not find a Position to create for id {id}.";
                throw new NotSupportedException(message);
            }
            return position;
        }
    }
